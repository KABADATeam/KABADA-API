using Kabada;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static KabadaAPI.MonthedCatalogRow;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  partial class BusinessPlanBL {
    protected CashFlow cf;
    protected MonthedCatalog mc;

    public int pendingInvestment;

    public int pPeriod { get { return NZ.Z(e.startup.period, 12); }}
    public short pYears { get { return (short)(pPeriod/12); }}

    public List<decimal?> refreshNecessaryCapital(bool createCSV=false, bool skipNecessaryCapitalUpdate=false){
      myCashFlow(!createCSV, skipNecessaryCapitalUpdate);
      var r=necessaryCapital();
      if(r.Where(x=>x!=null).FirstOrDefault()!=null)
        return r;
      return null;
      }

    //----------------------------------------- 1 ------------------------------------------//
    public byte[] xlsxBytes(bool skipCSV=false, bool skipNecessaryCapitalUpdate=false){
      var w=myCashFlow(skipCSV, skipNecessaryCapitalUpdate);
      return w.xlsxBytes(filePath("CashFlow.xlsx"), pYears);
      }

    public MemoryStream xlsxStream(bool skipCSV=false, bool skipNecessaryCapitalUpdate=false){
      var w=myCashFlow(skipCSV, skipNecessaryCapitalUpdate);
      return w.xlsxStream(pYears);
      }

    public CashFlow myCashFlow(bool skipCSV=false, bool skipNecessaryCapitalUpdate=false){
      loadTaxes();

      mc=new MonthedCatalog();
      fillBaseCash();

      cf=new CashFlow();
      myCashFlowInternal(skipNecessaryCapitalUpdate);
cf.createExcelFile(filePath("CashFlow.xlsx"));

      if(skipCSV==false)
        snapCSV();

      return cf;
      }

    //----------------------------------------- 2 ------------------------------------------//
 //   private List<Plan_OwnMoney> _ownMoney;
    private List<Plan_Loan> loans;
  //  private List<Plan_SaleForecast> productions;
    protected Plan_SaleForecast salesMaster;
    protected Plan_OwnMoney ownMaster;
    protected Plan_Loan loanMaster;
    protected Plan_Assets assetMaster;
    protected Plan_Cost fixMaster;
    protected Plan_Cost varMaster;

    protected void loadTaxes(){
      if(this._o.CountryId!=null){
        var cID=this._o.CountryId.Value;
        var uaRepo=new UniversalAttributeRepository(textSupport.blContext, textSupport.daContext);
        var vat=uaRepo.getVAT(cID);
        if(vat!=null)
           _vatTax=vat.e.StandardRate;
        var essr=uaRepo.getESSR(cID);
        if(essr!=null)
           _salaryTax=essr.recent();
        }
      }

    private void fillBaseCash() {
      loans=new List<Plan_Loan>();
      var s=this.e.startup;

//var pI=mc.add(CatalogRowKind.pendingInvestment, null, new MonthedDataRow()); pI.data.AddRange(new List<decimal?>(){ null, null, null, -4501.03m}); pendingInvestment=pI.id;

      //=======================OWN MONEY==========================================//
      ownMaster=new Plan_OwnMoney(mc, this);
      ownMaster.generateRecords(ownMoney());

      //=======================LOANs==========================================//
      loanMaster=new Plan_Loan(mc, this);
      loanMaster.generateRecords(loanList());

      loanMaster.generateTotalInitR(ownMaster);

      //=======================SALES FORECAST==========================================//
      salesMaster=new Plan_SaleForecast(mc, this);
      salesMaster.generateRecords(myProduct_s.OrderBy(x=>x.e.title).ToList());

      //======================COSTS.INVESTMENTS===ASSETS=================================//
      assetMaster=new Plan_Assets(mc, this);
      assetMaster.generateRecords(this.myKeyResource_s, textSupport.getKeyResourceMeta());

      //======================COSTS F/V====================================//
      fixMaster=new Plan_Cost(mc, this);
      fixMaster.generateRecords("Fixed costs (without VAT):", myFixedCost_s, KeyResourceBL.SFID);
      varMaster=new Plan_Cost(mc, this);
      varMaster.generateRecords("Variable costs (without VAT):", myVariableCost_s, KeyResourceBL.SVID);
      }

    protected List<decimal?> necessaryCapital(){
      var r=new List<decimal?>(){ null };
      if(pendingInvestment!=0)
        r=mc.get(pendingInvestment).data;
      return r;
      }

    protected CashFlow myCashFlowInternal(bool skipNecessaryCapitalUpdate) {
      cf.initialRevenue=initialRevenue;
      cf.salesForecast=salesForecast(cf.initialRevenue.summaries[0].monthlyValue[0]);
      cf.investments=investments;
      cf.variableCosts=varMaster.table("Variable costs (without VAT):"); // costs(myVariableCost_s, "Variable costs (without VAT):", KeyResourceBL.SVID);
      cf.fixedCosts=fixMaster.table("Fixed costs (without VAT):"); //costs(myFixedCost_s, "Fixed costs (without VAT):", KeyResourceBL.SFID);
      var sh=cf.variableCosts; // holder of summary
      sh.summaries=costsSummary(cf);
      var t=cf.fixedCosts.summRow("TOTAL COSTS", sh.summaries);
      sh.summaries.Add(t);
      cf.balances=makeBalances(cf.salesForecast.summaries[cf.salesForecast.summaries.Count-1], t);

      if(skipNecessaryCapitalUpdate==false){
        var ola=gS(PlanAttributeKind.necessaryCapital).Select(x=>new NecessaryCapitalBL(x)).FirstOrDefault();
        var f1=(ola==null).ToString().Substring(0,1).ToUpper();
        var n=necessaryCapital();
        var f2="F";
        if(n.Where(x=>x!=null).FirstOrDefault()!=null)
          f2="T";
        var sRepo=new Plan_SpecificAttributesRepository(textSupport.blContext);
        switch(f1+f2){  // old missing + new required
          case "FT": // must replace old
            var wo=new NecessaryCapitalBL(ola.id, sRepo, true);
            wo.e.RemoveRange(0, wo.e.Count);
            wo.e.AddRange(n);
            sRepo.daContext.SaveChanges();
            break;
          case "FF": // must delete old data
          case "TT": // create new
            ola=new NecessaryCapitalBL(o.Id);
            ola.e.AddRange(n);
            var w=ola.unload();
            sRepo.create(w);
            break;
           case "TF" : break; // nothing to do
          default: throw new Exception($"How '{f1}'+'{f2}'");
          }
        }

      return cf;
      }

    private void snapCSV() {
      mc.snapMe(filePath("CashBase.csv"));
      cf.snapMe(filePath("CashFlow.csv"));
      }

    //----------------------------------------- n ------------------------------------------//
    public string filePath(string tail){
      var fn=$"{textSupport.blContext.userGuid}.{textSupport.blContext.sessionId}.{DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss.fff")}"+tail;
      var path = Directory.GetCurrentDirectory(); 
      var r=Path.Combine(path, "Logs", fn);
      return r;
      }

    private CashFlowTable initialRevenue { get {
      var br=new CashFlowTable(){ title="Initial money revenue to start business:" };
      var r=new List<CashFlowRow>();
      br.rows=r;
      //var sum=0m;
      var t=new List<CashFlowRow>(){ ownMaster.revenueRow() };
      t.AddRange(loanMaster.revenueRows());
      foreach(var o in t){
        if(o.monthlyValue.Count<1)
          continue;
        r.Add(o);
//        sum+=NZ.Z(o.monthlyValue[0]);
        }

      //r.Add(new CashFlowRow("Owner's contribution", (e.startup.own_money==null?0:e.startup.own_money)+(e.startup.own_assets==null?0:e.startup.own_assets)));
      //r.Add(new CashFlowRow("Loan from bank/leasing company", e.startup.loan_amount));
      
      br.summaries=new List<CashFlowRow>(){ new CashFlowRow("Total initial revenue", mc.get(loanMaster.mcRevSumW).data[0])};
      if(pendingInvestment!=0){
        br.rows.Add(mc.expose(pendingInvestment, pPeriod));
        }
      return br;
      }}

    public CashFlowTable salesForecast(decimal? initialRevenue) { 
      var r=new CashFlowTable(){ rows=new List<CashFlowRow>(), title="Sales forcast (revenue from core business):" };
      r.rows=salesMaster.basicRows();
      //var vats=new CashFlowRow("VAT received - (PVN likmes), not calculated for export part outside EU", period: this.e.startup.period);
      //var n=(short)(vats.monthlyValue.Count-1);
      //var pi=myProduct_s.OrderBy(x=>x.e.title).ToList();
      //foreach(var p in pi){
      //  var rw=new CashFlowRow(p.e.title, period: n);
      //  r.rows.Add(rw);
      //  for(var m=1; m<=n; m++){
      //    var euS=p.euSale(m);
      //    rw.monthlyValue[m]=CashFlowRow.Sum(euS, p.noneuSale(m));
      //    if(euS!=null){
      //      var pc=p.e.salesForcast.sales_forecast_eu.Where(x=>x.month==m).FirstOrDefault();
      //      vats.monthlyValue[m]=CashFlowRow.Sum(vats.monthlyValue[m], money(pc.vat*euS/100));
      //      }
      //    }
      //  rw.totals();
      //  }
      var t=new List<CashFlowRow>(){ mc.expose(loanMaster.mcRevSumW, pPeriod) };
      r.summaries=salesMaster.summaries();
      t.AddRange(r.summaries);
      //r.summaries=new List<CashFlowRow>(){ r.summRow("TOTAL revenue from core business", r.rows), vats };
      //vats.totals();
      var tr=r.summRow("TOTAL REVENUE", t);
      tr.monthlyValue[0]=initialRevenue; //this.e.startup.total_investments;
      r.summaries.Add(tr);
      return r;
      }

    private decimal? money(decimal? v) {
      if(v==null)
        return null;
      return decimal.Round(v.Value, 2);
      }

    public CashFlowTable investments { get {
      var r=new CashFlowTable(){ title="Investments (without VAT):"};
      r.rows=assetMaster.getRows();
      //var rsi=myKeyResource_s;
      //var idi=rsi.Select(x=>x.texterId).Distinct().ToList();
      //var ti=textSupport.get(idi).ToDictionary(x=>x.Id, x=>x.MasterId);
      //var midi=ti.Where(x=>x.Value!=null && x.Value!=KeyResourceBL.HID).Select(x=>(Guid)x.Value).Distinct().ToList();
      //var mi=textSupport.get(midi).ToDictionary(x=>x.Id);
      //var gsi=myKeyResource_s.GroupBy(x=>ti[x.texterId]).ToDictionary(g => g.Key, g => g.Where(x=>x.e.amount!=null).ToList());
      //var rws=new List<CashFlowRow>();
      //foreach(var o in mi){
      //  var rw=new CashFlowRow(o.Value.Value);
      //  rws.Add(rw);
      //  var li=gsi[o.Key];
      //  if(li.Count>0)
      //    rw.monthlyValue[0]=li.Sum(x=>x.e.amount);
      //  rw.totals();
      //  }
      //if(rws.Count>0)
      //  r.rows=rws;
      return r;
      } }


    private CashFlowTable makeBalances(CashFlowRow totalRevenue, CashFlowRow totalExpenses) {
      var r=new CashFlowTable(){ rows=new List<CashFlowRow>()};
      var z=totalRevenue.minusots("Montly balance", totalExpenses);
      z.monthlyValue[0]=e.startup.working_capital_amount;
      r.rows.Add(z);
      r.rows.Add(beigubilance(z));
      return r;
      }

    private CashFlowRow beigubilance(CashFlowRow z) {
      var specRow=new CashFlowRow("Opening Cash", null);

      var t=new MonthedDataRow();

      short n=(short)(z.monthlyValue.Count-1);
      var r=new CashFlowRow("Total balance", period:n);
      decimal w=0;
      for(var m=0; m<=n; m++){
        w+=NZ.Z(z.monthlyValue[m]);
        r.monthlyValue[m]=w;
        specRow.monthlyValue.Add(w);
        t.Add(w>=0m?null:w);
        }
      
      cf.openingCash=new CashFlowTable(){ rows=new List<CashFlowRow>(){ specRow }};
      
      if(t.Where(x=>x!=null).FirstOrDefault()!=null){
        pendingInvestment=mc.add(CatalogRowKind.unspecified, "", t).id;
        cf.initialRevenue.rows.Add(mc.expose(pendingInvestment, pPeriod));
        }

      return r;
      }

    private List<CashFlowRow> costsSummary(CashFlow basic) {
      var r=new List<CashFlowRow>();
      var t=mc.plus(CatalogRowKind.costValue, "SUM of all costs and investments", fixMaster.mcVal, varMaster.mcVal);
      
      //var visi=new List<CashFlowRow>();
      //if(basic.variableCosts!=null)
      //  visi=basic.variableCosts.rows.GetRange(0, basic.variableCosts.rows.Count);
      //if(basic.fixedCosts!=null)
      //  visi.AddRange(basic.fixedCosts.rows.GetRange(0, basic.fixedCosts.rows.Count));
      //var t=basic.fixedCosts.summRow("SUM of Variable costs, fixed costs and additional investments in current assets:", visi);
      var x=assetMaster.investments();
      t.data.set(0, NZ.Np(t.data.get(0), x));
      //if(t.data.Count>0)
      //  t.data[0]=NZ.Np(t.data[0], x);
      // else
      //  t.data.Add(x);
      r.Add(t.expose(pPeriod));
      
      t=mc.plus(CatalogRowKind.costVat, "VAT Input", fixMaster.mcVat, varMaster.mcVat);
      var rw2=new List<decimal?>(){ null };
      rw2.AddRange(t.data);
      t.data=new MonthedDataRow(rw2);
      t.data.set(1,assetMaster.vat());
      //t.data[1]=assetMaster.vat();
      r.Add(t.expose(pPeriod));
 
      //visi=new List<CashFlowRow>();
      //if(basic.variableCosts!=null)
      //  visi=basic.variableCosts.normalRows();
      //if(basic.fixedCosts!=null)
      //  visi.AddRange(basic.fixedCosts.normalRows());
      //var tmp=basic.fixedCosts.summRow("---", visi);
      //r.Add(tmp.multoRow("VAT Input", vatTax));

      r.AddRange(loaner());
      return r;
      }

    private decimal? _salaryTax;
    public decimal? salaryTax { get { return _salaryTax/100m; }}
    private decimal? _vatTax;
    private decimal? vatTax { get { return _vatTax/100m; }}

    private CashFlowTable costs(List<CostBL> myCosts, string titel=null, Guid? salaryID=null) {
      if(myCosts.Count<1)
        return null;
      foreach(var o in myCosts)
        o.fillMyCashFlow(e.startup.period); // basic cash flow
      var us=myCosts.Where(x=>x.myCashFlow!=null).ToList();
      if(us.Count<1)
        return null;
      var r=new CashFlowTable(){ rows=new List<CashFlowRow>(), title=titel };
      // summ by groups
      var idi=us.Select(x=>x.texterId).Distinct().ToList();
      var ti=textSupport.get(idi).ToDictionary(x=>x.Id, x=>x.MasterId);
      var midi=ti.Where(x=>x.Value!=null && x.Value!=KeyResourceBL.HID).Select(x=>(Guid)x.Value).Distinct().ToList();
      var mi=textSupport.get(midi).OrderBy(x=>x.Value).ToList();
      var gsi=us.GroupBy(x=>ti[x.texterId]).ToDictionary(g => g.Key, g => g.ToList());
      var n=this.e.startup.period.Value;
      foreach(var o in mi){
        var rw=new CashFlowRow(o.Value, period:n);
        r.rows.Add(rw);
        var li=gsi[o.Id];
        for(short m=1; m<=n; m++){
          rw.monthlyValue[m]=CashFlowRow.Sum(gsi[o.Id].Select(x=>x.myCashFlow.monthlyValue[m]));
          var vat=CashFlowRow.Sum(gsi[o.Id]
            .Select(x=>NZ.Nr(NZ.Z(x.myCashFlow.monthlyValue[m])*NZ.Z(x.e.vat)/100m)));
          }
        rw.totals();

        if(o.Id==salaryID){ // || o.Value=="Salaries"){
          if(r.specialRows!=null)
            throw new Exception("Special rows already present...");

          var k=r.rows.Count;
          r.specialRows=k-1;
          r.rows.Add(rw.multoRow("Labor taxes", salaryTax, 1));
          }
        }

//TODO      // subtract investments
      return r;
      }

    protected List<CashFlowRow> loaner(){ return loanMaster.costsRows(); }

    //private CashFlowRow atlikums;
    //protected List<CashFlowRow> loaner(){
    //  var s=e.startup;
    //  atlikums=new CashFlowRow("(DEBUG: atlikusī pamatsumma)", s.loan_amount, s.period);
    //  var pamatMaksa=new CashFlowRow("Loan principal - Aizdevumu pamatsumma", null, s.period);
    //  var procenti=new CashFlowRow("Loan interest - Aizdevumu procenti", null, s.period);
    //  var r=new List<CashFlowRow>(){ procenti, pamatMaksa };
    //  if(s.loan_amount==null || s.loan_amount==0)
    //    return r;
    //  var dura=s.payment_period;
    //  if(dura==null)
    //    dura=s.period;
    //  short skipa=0;
    //  if(s.grace_period!=null && s.grace_period>0)
    //    skipa=s.grace_period.Value;
    //  dura-=skipa;
    //  var chunk=money((s.loan_amount/dura).Value);
    //  for(var m=skipa; m<=dura && m<=s.period; m++)
    //    pamatMaksa.monthlyValue[m]=chunk;
    //  for(var m=1; m<=s.period; m++){
    //    var t=pamatMaksa.monthlyValue[m-1];
    //    atlikums.monthlyValue[m]=atlikums.monthlyValue[m-1]-(t==null?0:t.Value);
    //    if(pamatMaksa.monthlyValue[m]!=null && pamatMaksa.monthlyValue[m]>atlikums.monthlyValue[m])
    //      pamatMaksa.monthlyValue[m]=atlikums.monthlyValue[m];
    //    procenti.monthlyValue[m]=money(atlikums.monthlyValue[m]*(s.interest_rate/1200));
    //    }
    //  return r;
    //  }
    }
  }
