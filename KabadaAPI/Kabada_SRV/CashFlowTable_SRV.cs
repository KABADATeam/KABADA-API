using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class CashFlowTable {
    internal CashFlowRow summRow(string v, List<CashFlowRow> us) {
      var n=(short)(us[0].monthlyValue.Count-1);
      var sr=new CashFlowRow(v, period:n);
      for(var m=0; m<=n; m++)
        sr.monthlyValue[m]=CashFlowRow.Sum(us.Select(x=>x.monthlyValue[m]));
      sr.totals();
      return sr;
      }
    }
  }
