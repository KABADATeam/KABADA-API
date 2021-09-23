using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class CashFlowTable {
    internal CashFlowRow summRow(string v, List<CashFlowRow> us) {
      var are=(us!=null && us.Count>0);
      short n=are?((short)(us[0].monthlyValue.Count-1)):(short)12;
      var sr=new CashFlowRow(v, period:n);
      if(are==false)
        return sr;
      for(var m=0; m<=n; m++)
        sr.monthlyValue[m]=CashFlowRow.Sum(us.Select(x=>x.monthlyValue[m]));
      sr.totals();
      return sr;
      }
    }
  }
