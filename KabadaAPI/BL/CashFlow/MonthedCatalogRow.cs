namespace KabadaAPI {
  public class MonthedCatalogRow {
    public enum CatalogRowKind { unspecified=0, financialInvestment=1, actualDebt=2, payback=3, percentPayment=4 }

    public int id { get; protected set; }
    public CatalogRowKind kind;
    public string master;
    public string title;
    public MonthedDataRow data;

    public MonthedCatalogRow(int id, string title=null, MonthedDataRow data=null) { this.id=id; this.title=title; this.data=(data==null)?new MonthedDataRow() : data; }
    }
  }
