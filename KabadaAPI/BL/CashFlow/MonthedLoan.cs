using System.Collections.Generic;

namespace KabadaAPI {
  public class MonthedLoan {
    public short   project_period;
    public string  myTitle;
    public decimal loan_amount;
    public decimal interest_rate; // a year, >=0
    public short   payment_period; // >0
    public short   grace_period;   // >=0
    public short   start_month;    // >=0

    public List<decimal?> additional_sums; // the 0 element is for start_month+1

    public MonthedLoan(string title, short? project_period1, short? grace_period1, decimal? interest_rate1, decimal? loan_amount1, short? payment_period1) {
      myTitle=title;
      project_period=(short)((project_period1==null)?12:project_period1.Value);
      grace_period=(short)((grace_period1==null)?0:grace_period1.Value);
      interest_rate=((interest_rate1==null)?0m:interest_rate1.Value);
      loan_amount=((loan_amount1==null)?0m:loan_amount1.Value);
      payment_period=(short)((payment_period1==null)?0:payment_period1.Value);
      }

    public int mcIn { get; protected set; }
    public int mcDebt { get; protected set; }
    public int mcPay { get; protected set; }
    public int mcPerc { get; protected set; }

    protected MonthedDataRow incomingMoney() {
      var r=new MonthedDataRow();
      for(var i=0; i<start_month; i++) r.Add(0m);
      r.Add(loan_amount);
      if(additional_sums!=null){
        foreach(var o in additional_sums) r.Add((o==null)?0m:o);
        }
      return r;
      }
 

    public short lastMonth { get { return (short)(start_month+payment_period); }}

    public void generateRecords(MonthedCatalog catalog){
      var inc=catalog.add(myTitle+" LOAN.in", incomingMoney()); mcIn=inc.myId;
      var debt=catalog.add(myTitle+" LOAN.debt", new MonthedDataRow(lastMonth+1)); mcDebt=debt.myId;
      var pay=catalog.add(myTitle+" LOAN.pay", new MonthedDataRow(lastMonth+1)); mcPay=pay.myId;
      var percent=catalog.add(myTitle+" LOAN.percent", new MonthedDataRow(lastMonth+1)); mcPerc=percent.myId;
      buildPayDebt(inc.myData, debt.myData, pay.myData, percent.myData);
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
