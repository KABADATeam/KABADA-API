using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KabadaAPI.MonthedCatalogRow;

namespace KabadaAPI {
  public class OwnMoney {
    public short   project_period;
    public string  myTitle;
    public List<decimal?> additional_sums; // the 0 element is for start_month+1

    public int mcIn;

    public OwnMoney(string title, short? period, List<decimal?> list) {
      project_period=(period==null)?(short)12:period.Value;
      myTitle=title;
      additional_sums=list;
      }

    internal void generateRecords(MonthedCatalog catalog) {
      var inc=catalog.add(CatalogRowKind.financialInvestment, myTitle, incomingMoney()); mcIn=inc.id;
      }

    private MonthedDataRow incomingMoney() {
      var r=new MonthedDataRow();
      foreach(var o in additional_sums) r.Add((o==null)?0m:o);
      return r;
      }
    }
  }
