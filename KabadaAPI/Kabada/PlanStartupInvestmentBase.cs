namespace Kabada {
  public partial class PlanStartupInvestmentBase  {
    public short?   period; // "12 or 24",
    public bool?    vat_payer;
    public decimal? total_investments;
    //asserts part
    public decimal? investment_amount;  // total_investments-own_assets
    public decimal? own_money;
    public decimal? own_assets;    
    public decimal? loan_amount;    // investment_amount-own_money
    //business financing part
    public short? payment_period; // any value from range: 6, 12, 18, ...., 120
    public decimal? interest_rate;
    public short? grace_period; //Max months: payment_period - 6 (12 months - 6 = 6 or 24 months  - 6 = 18), 0 by default
    public short? payment_period_short; //Max months: Selected cash flow period - 1 (12 months - 1 = 11 or  24 months  - 1 = 23)
    public decimal? interest_rate_short;
    public short? grace_period_short; 
    //working capital part
    public decimal? working_capital_amount; 
    public decimal? own_money_short;
    public decimal? loan_amount_short;
    }
}
