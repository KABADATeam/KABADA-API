namespace Kabada {
  public class PlanStartupInvestmentBase {
    public short? period; // "12 or 24",
    public bool? vat_payer;
    public decimal? total_investments;
    public decimal? own_money;
    public decimal? loan_amount;    // total_investments minus own_money
    public short? payment_period; // any value from range: 6, 12, 18, ...., 60
    public decimal? interest_rate;
    public decimal? grace_period;
    }
  }
