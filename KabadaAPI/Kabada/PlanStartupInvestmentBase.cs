namespace Kabada {
  public class PlanStartupInvestmentBase  {
    public short?   period; // "12 or 24",
    public bool?    vat_payer;
    public decimal? total_investments;
    public decimal? investment_amount;  // total_investments-own_assets
    public decimal? own_money;
    public decimal? own_assets;    
    public decimal? loan_amount;    // investment_amount-own_money
    public short? payment_period; // any value from range: 6, 12, 18, ...., 120
    public decimal? interest_rate;
    public short? grace_period;
    }
  }
