using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KabadaAPI.MonthedCatalogRow;

namespace KabadaAPI {
  public class OwnMoney : FinancialInvestment {
    //public short   project_period;
    //public string  myTitle;
    //public List<decimal?> additional_sums; // the 0 element is for start_month+1

    //public int mcIn;

    public OwnMoney(string title, short? period, List<decimal?> list) : base(title, period,list) {}
      //setPeriod(period);
      ////project_period=(period==null)?(short)12:period.Value;
      //myTitle=title;
      //investmentAmounts=list;
      //}

    //internal void generateRecords(MonthedCatalog catalog) {
    //  var inc=catalog.add(CatalogRowKind.financialInvestment, myTitle, makeIncomingMoney()); mcIn=inc.id;
    //  }

    //private MonthedDataRow incomingMoney() {
    //  var r=new MonthedDataRow();
    //  foreach(var o in investmentAmounts) r.Add((o==null)?0m:o);
    //  return r;
    //  }
    }
  }
