namespace KabadaAPI {
  public class LoanElementBL : InvestmentElementBL {
    public short payment_period;
    public decimal interest_rate;
    public short grace_period;
    public short start_month;

    public LoanElementBL() {} 
    public LoanElementBL(string title, decimal? startup=null) : base(title, startup){}
   }
  }
