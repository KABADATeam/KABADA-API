﻿using Kabada;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.MonthedCatalogRow;

namespace KabadaAPI {
  public class Plan_Loan : FinancialInvestment {
    //===================MASTER===============================//
    protected Plan_Loan dad { get { return (Plan_Loan)_dad;}}
    protected List<Plan_Loan> slaves;

    public Plan_Loan(MonthedCatalog catalog, BusinessPlanBL businessPlan) {
      _mc=catalog; _bp=businessPlan;
      slaves=new List<Plan_Loan>();
      }

    internal void generateRecords(List<LoanElementBL> us) {
      foreach (var p in us) {
        var o = new Plan_Loan(this, p);
        slaves.Add(o);
        o.generateRecords();
        }
//      generateSumRecords();
      }

    public int mcRevSum { get; protected set; }
    public int mcRevSumW { get; protected set; }

    //protected int summRow;

    //private void generateSumRecords() {
    //  //var s=_mc.add(CatalogRowKind.ownMoneySum, "OwnMoney", new MonthedDataRow());
    //  //summRow=s.id;
    //  //var db=slaves.Select(x=>_mc.get(x.mcInW).data).ToList();
    //  //for(var m=0; m<=_bp.pPeriod; m++)
    //  //  s.data.Add(NZ.Np(db.Select(x=>x.get(m))));
    //  }

    internal List<CashFlowRow> revenueRows() {
      var r=new List<CashFlowRow>();
      foreach(var o in slaves)
        r.Add(o.revenueRow());
      return r;
      }

    internal void generateTotalInitR(Plan_OwnMoney ownMaster) {
      var t=new List<MonthedCatalogRow>(){  mc.get(ownMaster.summRow) };
      foreach(var o in slaves)
        t.Add(mc.get(o.mcIn));
      var n=t.Select(x=>x.data.Count).Max();
      var sumis=new MonthedDataRow(n);
      var w=mc.add(CatalogRowKind.initialRevenue, "TOTAL initial revenue", sumis); mcRevSum=w.id;
      for(var m=0; m<n; m++)
        sumis[m]=NZ.Np(t.Select(x=>x.data.get(m)));
      mcRevSumW=windowIt(bp.pPeriod, mcRevSum, CatalogRowKind.initialRevenueW); 
      }

    //===================SLAVE===============================//
    LoanElementBL p;
    protected decimal interest_rate { get { return p.interest_rate; }}
    protected short payment_period { get { return p.payment_period; }} // >0
    protected short grace_period { get { return p.grace_period; }}   // >=0
    protected short start_month;    // >=0
    protected short lastMonth { get { return (short)(start_month+payment_period); }}

    public Plan_Loan(Plan_Loan master, LoanElementBL element) {
      _dad=master; this.p=element;
      for(short m=0; m<p.Count; m++)
        if(p[m]!=null && p[m]!=0m) { start_month=m; break; }
      }

    public int mcDebt { get; protected set; }
    public int mcDebtW { get; protected set; }
    public int mcPay { get; protected set; }
    public int mcPayW { get; protected set; }
    public int mcPerc { get; protected set; }
    public int mcPercW { get; protected set; }

    protected void generateRecords() {
      generateIncoming(mc, p);
      makeOther();
      }

    protected void makeOther() {
      var inc=mc.get(mcIn);
      var debt=mc.add(CatalogRowKind.actualDebt, p.title, new MonthedDataRow(lastMonth+1)); mcDebt=debt.id;
      var pay=mc.add(CatalogRowKind.payback, $"Aizdevumu pamatsumma ({p.title})", new MonthedDataRow(lastMonth+1)); mcPay=pay.id;
      var percent=mc.add(CatalogRowKind.percentPayment, $"Aizdevumu procenti ({p.title})", new MonthedDataRow(lastMonth+1)); mcPerc=percent.id;
      buildPayDebt(inc.data, debt.data, pay.data, percent.data);
      mcDebtW=windowIt(project_period, mcDebt, CatalogRowKind.actualDebtW, true);
      mcPayW=windowIt(project_period, mcPay, CatalogRowKind.paybackW);
      mcPercW=windowIt(project_period, mcPerc, CatalogRowKind.percentPaymentW);
      }

    private CashFlowRow revenueRow() { return mc.expose(mcInW, project_period); }

    private void buildPayDebt(MonthedDataRow inc, MonthedDataRow debt, MonthedDataRow pay, MonthedDataRow perc) {
      debt[0]=inc[0]; pay[0]=0m; perc[0]=0m;
      var multa=interest_rate/1200m;
      var nop=((start_month==0)?1:start_month)+grace_period;
      for(var m=0; m<lastMonth; m++){
        var m1=m+1;
        debt[m1]=debt[m]-pay[m];
        if((inc.Count-1)>m1 && inc[m1]!=null)
          debt[m1]+=inc[m1].Value;
        pay[m1]=(m1>=nop)?decimal.Round((debt[m1].Value/(lastMonth-m1+1)), 2):0m;
        perc[m1]=decimal.Round(multa*debt[m1].Value, 2);
        }
      }
    }
  }