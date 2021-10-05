using Kabada;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KabadaAPI {
  partial class BusinessPlanBL {
    protected CashFlow cf;
    protected MonthedCatalog mc;

    public int pPeriod { get { return NZ.Z(e.startup.period, 12); }}

    //----------------------------------------- 1 ------------------------------------------//
    public CashFlow myCashFlow(){
      loadTaxes();

      mc=new MonthedCatalog();
      fillBaseCash();

      cf=new CashFlow();
      myCashFlowInternal();

      snapCSV();

      return cf;
      }

    //----------------------------------------- 2 ------------------------------------------//
    private List<OwnMoney> ownMoney;
    private List<MonthedLoan> loans;
    private List<Production> productions;

    protected void loadTaxes(){
      if(this._o.Country!=null){
        var cID=this._o.Country.Id;
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
      loans=new List<MonthedLoan>();
      var s=this.e.startup;

      //=======================LOANs==========================================//
      var w=new MonthedLoan("Long term", s.period, s.grace_period, s.interest_rate, s.payment_period, s.loan_amount);
      loans.Add(w);
      w.generateRecords(mc);

      w=new MonthedLoan("Short term", s.period, null, 8, 10, 23000) { investmentAmounts=new List<decimal?>(){null, null, 15739.52m, 34692.81m}};;
      loans.Add(w);
      w.generateRecords(mc);

      //=======================OWN MONEY==========================================//
      var own=new OwnMoney("Own money", s.period, new List<decimal?>(){20000, null, 500m, 34000m});
      own.generateRecords(mc);
      ownMoney=new List<OwnMoney>(){ own };

      //=======================SALES FORECAST==========================================//
      productions=new List<Production>();
      var pi=myProduct_s.OrderBy(x=>x.e.title).ToList();
      foreach(var p in pi){
        var o=new Production(p);
        o.generateRecords(mc, this);
        productions.Add(o);
        }
      var sms=Production.GenerateSumRecords(mc, productions, this);
      }

    protected CashFlow myCashFlowInternal(){
      cf.initialRevenue=initialRevenue;
      cf.salesForecast=salesForecast(cf.initialRevenue.summaries[0].monthlyValue[0]);
      cf.investments=investments;
      cf.variableCosts=costs(myVariableCost_s, "Variable costs (without VAT):", KeyResourceBL.SVID);
      cf.fixedCosts=costs(myFixedCost_s, "Fixed costs (without VAT):", KeyResourceBL.SFID);
      cf.fixedCosts.summaries=costsSummary(cf);
      var t=cf.fixedCosts.summRow("Total Expenses - KOPĒJIE IZDEVUMI", cf.fixedCosts.summaries);
      //cf.fixedCosts.summaries.Add(atlikums);   // DEBUG row
      cf.fixedCosts.summaries.Add(t);
      cf.balances=makeBalances(cf.salesForecast.summaries[cf.salesForecast.summaries.Count-1], t);
      //cf.snapMe();
      return cf;
      }

    private void snapCSV() {
      cf.snapMe(filePath("CashFlow.csv"));
      mc.snapMe(filePath("CashBase.csv"));
      }

    //----------------------------------------- n ------------------------------------------//
    private string filePath(string tail){
      var fn=$"{textSupport.blContext.userGuid}.{textSupport.blContext.sessionId}.{DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss")}"+tail;
      var path = Directory.GetCurrentDirectory(); 
      var r=Path.Combine(path, "Logs", fn);
      return r;
      }

    private CashFlowTable initialRevenue { get {
      var br=new CashFlowTable(){ title="Initial revenue to start business:" };
      var r=new List<CashFlowRow>();
      br.rows=r;
      r.Add(new CashFlowRow("Owner's contribution", (e.startup.own_money==null?0:e.startup.own_money)+(e.startup.own_assets==null?0:e.startup.own_assets)));
      r.Add(new CashFlowRow("Loan from bank/leasing company", e.startup.loan_amount));
      
      br.summaries=new List<CashFlowRow>(){ new CashFlowRow("Total initial revenue", e.startup.total_investments)};
      return br;
      }}

    public CashFlowTable salesForecast(decimal? initialRevenue) { 
      var r=new CashFlowTable(){ rows=new List<CashFlowRow>(), title="Sales forcast (revenue from core business):" };
      var vats=new CashFlowRow("VAT received - (PVN likmes), not calculated for export part outside EU", period: this.e.startup.period);
      var n=(short)(vats.monthlyValue.Count-1);
      var pi=myProduct_s.OrderBy(x=>x.e.title).ToList();
      foreach(var p in pi){
        var rw=new CashFlowRow(p.e.title, period: n);
        r.rows.Add(rw);
        for(var m=1; m<=n; m++){
          var euS=p.euSale(m);
          rw.monthlyValue[m]=CashFlowRow.Sum(euS, p.noneuSale(m));
          if(euS!=null){
            var pc=p.e.salesForcast.sales_forecast_eu.Where(x=>x.month==m).FirstOrDefault();
            vats.monthlyValue[m]=CashFlowRow.Sum(vats.monthlyValue[m], money(pc.vat*euS/100));
            }
          }
        rw.totals();
        }
      r.summaries=new List<CashFlowRow>(){ r.summRow("TOTAL revenue from core business", r.rows), vats };
      vats.totals();
      var tr=r.summRow("TOTAL REVENUE", r.summaries);
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
      var r=new CashFlowTable(){ title="Investments:"};
      var rsi=myKeyResource_s;
      var idi=rsi.Select(x=>x.texterId).Distinct().ToList();
      var ti=textSupport.get(idi).ToDictionary(x=>x.Id, x=>x.MasterId);
      var midi=ti.Where(x=>x.Value!=null && x.Value!=KeyResourceBL.HID).Select(x=>(Guid)x.Value).Distinct().ToList();
      var mi=textSupport.get(midi).ToDictionary(x=>x.Id);
      var gsi=myKeyResource_s.GroupBy(x=>ti[x.texterId]).ToDictionary(g => g.Key, g => g.Where(x=>x.e.amount!=null).ToList());
      var rws=new List<CashFlowRow>();
      foreach(var o in mi){
        var rw=new CashFlowRow(o.Value.Value);
        rws.Add(rw);
        var li=gsi[o.Key];
        if(li.Count>0)
          rw.monthlyValue[0]=li.Sum(x=>x.e.amount);
        rw.totals();
        }
      if(rws.Count>0)
        r.rows=rws;
      return r;
      } }


    private CashFlowTable makeBalances(CashFlowRow totalRevenue, CashFlowRow totalExpenses) {
      var r=new CashFlowTable(){ rows=new List<CashFlowRow>()};
      var z=totalRevenue.minusots("Montly balance - Mēneša bilance", totalExpenses);
      r.rows.Add(z);
      r.rows.Add(beigubilance(z));
      return r;
      }

    private CashFlowRow beigubilance(CashFlowRow z) {
      short n=(short)(z.monthlyValue.Count-1);
      var r=new CashFlowRow("Total balance - Beigu bilance", period:n);
      decimal? w=0;
      for(var m=0; m<=n; m++){
        w+=z.monthlyValue[m];
        r.monthlyValue[m]=w;
        }
      return r;
      }

    private List<CashFlowRow> costsSummary(CashFlow basic) {
      var r=new List<CashFlowRow>();
      var visi=new List<CashFlowRow>();
      if(basic.variableCosts!=null)
        visi=basic.variableCosts.rows.GetRange(0, basic.variableCosts.rows.Count);
      if(basic.fixedCosts!=null)
        visi.AddRange(basic.fixedCosts.rows.GetRange(0, basic.fixedCosts.rows.Count));
      var t=basic.fixedCosts.summRow("SUM of Variable costs, fixed costs", visi);
      r.Add(t);
 
      visi=new List<CashFlowRow>();
      if(basic.variableCosts!=null)
        visi=basic.variableCosts.normalRows();
      if(basic.fixedCosts!=null)
        visi.AddRange(basic.fixedCosts.normalRows());
      var tmp=basic.fixedCosts.summRow("---", visi);
      r.Add(tmp.multoRow("VAT input - PVN priekšnodoklis (ņem vērā katras izmaksas PVN likmes apmēru", vatTax));

      r.AddRange(loaner());
      return r;
      }

    private decimal? _salaryTax;
    private decimal? salaryTax { get { return _salaryTax/100m; }}
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
        for(short m=1; m<=n; m++)
          rw.monthlyValue[m]=CashFlowRow.Sum(gsi[o.Id].Select(x=>x.myCashFlow.monthlyValue[m]));
        rw.totals();

        if(o.Id==salaryID){ // || o.Value=="Salaries"){
          if(r.specialRows!=null)
            throw new Exception("Special rows already present...");

          var k=r.rows.Count;
          r.specialRows=k-1;
          r.rows.Add(rw.multoRow("Labor taxes (katrai valstij savs %)", salaryTax));
          }
        }

//TODO      // subtract investments




      return r;
      }

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

    protected List<CashFlowRow> loaner(){
      var r=new List<CashFlowRow>();
      foreach(var x in loans){
        r.Add(mc.expose(x.mcPayW, pPeriod));
        r.Add(mc.expose(x.mcPercW, pPeriod));
        }
      return r;
      }
    }
  }
