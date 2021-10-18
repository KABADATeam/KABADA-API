using KabadaAPI;
using System;

namespace Kabada {
  partial class PlanStartupInvestmentBase {
    public short   my_period(){ 
      if(period==null)
        return 12;
      return period.Value;
      }
    public bool    my_vat_payer(){ return (vat_payer==true); }
    public decimal my_total_investments() { return NZ.Z(total_investments); }
    public decimal my_investment_amount() { return NZ.Z(investment_amount); }
    public decimal my_own_money() { return NZ.Z(own_money); }
    public decimal my_own_assets() { return NZ.Z(own_assets); }
    public decimal my_loan_amount() { return NZ.Z(loan_amount); }
    public short   my_payment_period() { return (short)NZ.Z(payment_period); }
    public decimal my_interest_rate() { return NZ.Z(interest_rate); }
    public short   my_grace_period() { return (short)NZ.Z(grace_period); }
    public short   my_payment_period_short() { return (short)NZ.Z(payment_period_short); }
    public decimal my_interest_rate_short() { return NZ.Z(interest_rate_short); }
    public short   my_grace_period_short() { return (short)NZ.Z(grace_period_short); }
    public decimal my_working_capital_amount() { return NZ.Z(working_capital_amount); }
    public decimal my_startup_own_money() { return NZ.Z(startup_own_money); }
    public decimal my_startup_loan_amount() { return NZ.Z(startup_loan_amount); }

    public void validate(){
      var t=my_period();
      if(t!=12 && t!=24)
        throw new Exception($"the project period={t} is not allowed");
      //t=my_payment_period();
      //var w=(t / 6)*6;
      //if(w!=t || w<6 || w>120)
      //  throw new Exception($"Invalid payment_period specified '{payment_period}'");
      validateLoan("Long term", my_loan_amount(), my_payment_period(), my_interest_rate(), my_grace_period(), 120);
      validateLoan("Short term", my_startup_loan_amount(), my_payment_period_short(), my_interest_rate_short(), my_grace_period_short(), my_period()-1);
      }

    private void validateLoan(string titel, decimal amount, short period, decimal rate, short grace, int maxperiod) {
      if(amount==0m)
        return; // no loan at all
      if(amount<0m)
        throw new Exception($"{titel}: wrong amount='{amount}'");
      if(period<1 || period>maxperiod)
        throw new Exception($"{titel}: wrong period='{period}'");
      if(rate<0m)
        throw new Exception($"{titel}: wrong rate='{rate}'");
      if(grace<0 || grace>(my_period()-6))
        throw new Exception($"{titel}: wrong grace='{grace}'");
      }

    public void set(PlanStartupInvestmentBase o){
      period=o.period;
      vat_payer=o.vat_payer;
      total_investments=o.total_investments;
      investment_amount=o.investment_amount;
      own_money=o.own_money;
      own_assets=o.own_assets;
      loan_amount=o.loan_amount;
      payment_period=o.payment_period;
      interest_rate=o.interest_rate;
      grace_period=o.grace_period;
      payment_period_short=o.payment_period_short;
      interest_rate_short=o.interest_rate_short;
      grace_period_short=o.grace_period_short;
      working_capital_amount=o.working_capital_amount;
      startup_own_money=o.startup_own_money;
      startup_loan_amount=o.startup_loan_amount;
      }
    }
  }
