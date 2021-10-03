namespace KabadaAPI {
  public class MonthedCatalogRow {
    public int myId { get; protected set; }
    public string myTitle;
    public MonthedDataRow myData;

    public MonthedCatalogRow(int id, string title=null, MonthedDataRow data=null) { myId=id; myTitle=title; myData=(data==null)?new MonthedDataRow():data; }
    }
  }
