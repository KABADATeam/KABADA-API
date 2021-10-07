namespace KabadaAPI {
  public class InvestmentElementBL : MonthedDataRow {
    public InvestmentElementBL() { }
    public string title;

    public InvestmentElementBL(string title, decimal? startup=null) : base(startup){ this.title=title; }
    }
  }
