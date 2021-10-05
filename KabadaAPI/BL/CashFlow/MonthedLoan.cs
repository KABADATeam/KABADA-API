using System.Collections.Generic;
using static KabadaAPI.MonthedCatalogRow;

namespace KabadaAPI {
  public class MonthedLoan : FinancialInvestment {
    public decimal loan_amount;
    public decimal interest_rate; // a year, >=0
    public short   payment_period; // >0
    public short   grace_period;   // >=0
    public short   start_month;    // >=0

    public MonthedLoan(string title, short? project_period, short? grace_period, decimal? interest_rate, short? payment_period,
        decimal? startMonthLoan=null, List<decimal?> loanValues=null) 
       : base(title, project_period, loanValues) {
      this.grace_period=(short)NZ.Z(grace_period);
      this.interest_rate=NZ.Z(interest_rate);
      this.payment_period=(short)NZ.Z(payment_period);
      if(startMonthLoan!=null){
        if(investmentAmounts==null)
          investmentAmounts=new List<decimal?>(){ startMonthLoan };
         else {
          if(investmentAmounts.Count<1)
            investmentAmounts.Add(startMonthLoan);
           else
            investmentAmounts[0]=NZ.Zp(startMonthLoan, investmentAmounts[0]);
          }
        }
      loan_amount=((startMonthLoan==null)?0m:startMonthLoan.Value);
      }

    public int mcDebt { get; protected set; }
    public int mcDebtW { get; protected set; }
    public int mcPay { get; protected set; }
    public int mcPayW { get; protected set; }
    public int mcPerc { get; protected set; }
    public int mcPercW { get; protected set; }
 

    public short lastMonth { get { return (short)(start_month+payment_period); }}

    protected override void makeOther() {
      var inc=mc.get(mcIn);
      var debt=mc.add(CatalogRowKind.actualDebt, myTitle, new MonthedDataRow(lastMonth+1)); mcDebt=debt.id;
      var pay=mc.add(CatalogRowKind.payback, $"Aizdevumu pamatsumma ({myTitle})", new MonthedDataRow(lastMonth+1)); mcPay=pay.id;
      var percent=mc.add(CatalogRowKind.percentPayment, $"Aizdevumu procenti ({myTitle})", new MonthedDataRow(lastMonth+1)); mcPerc=percent.id;
      buildPayDebt(inc.data, debt.data, pay.data, percent.data);
      mcDebtW=windowIt(mcDebt, CatalogRowKind.actualDebtW, true);
      mcPayW=windowIt(mcPay, CatalogRowKind.paybackW);
      mcPercW=windowIt(mcPerc, CatalogRowKind.percentPaymentW);
      }

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
