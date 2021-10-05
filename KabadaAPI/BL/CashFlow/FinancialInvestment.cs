using System.Collections.Generic;
using static KabadaAPI.MonthedCatalogRow;

namespace KabadaAPI {
  public class FinancialInvestment {
    public short   project_period;
    public string  myTitle;
    public List<decimal?> investmentAmounts; // the 0 element is for start_month 

    protected MonthedCatalog mc;

    public int mcIn; // montlyTable.financialInvestment
    public int mcInW; // montlyTable.financialInvestment windowed

    protected void setPeriod(short? period){ project_period=(short)NZ.Z(period, 12); }

    public FinancialInvestment() {}
    public FinancialInvestment(string title, short? period, List<decimal?> list) {
      setPeriod(period);
      myTitle=title;
      investmentAmounts=list;
      }

    protected MonthedDataRow makeIncomingMoney(int start_month=0) {
      var r=new MonthedDataRow();
      for(var i=0; i<start_month; i++) r.Add(0m);
      if(investmentAmounts!=null){
        foreach(var o in investmentAmounts) r.Add(NZ.Z((o)));
        }
      return r;
      }

    protected virtual void makeOther(){}

    internal void generateRecords(MonthedCatalog catalog) {
      mc=catalog;
      var inc=catalog.add(CatalogRowKind.financialInvestment, myTitle, makeIncomingMoney()); mcIn=inc.id;
      mcInW=windowIt(mcIn, CatalogRowKind.financialInvestmentW);
      makeOther();
      }

    protected int windowIt(int mcId, CatalogRowKind kind=CatalogRowKind.unspecified, bool keepPostAsIs=false){
      var o=mc.get(mcId);
      var w=o.data.window(project_period, keepPostAsIs);
      var n=mc.add(kind, o.title, w);
      return n.id;
      }
    }
  }
