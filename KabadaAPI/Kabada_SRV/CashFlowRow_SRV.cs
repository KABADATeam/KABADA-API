using System.Collections.Generic;

namespace Kabada {
  partial class CashFlowRow {
    public CashFlowRow() { monthlyValue=new List<decimal?>(); }
    public CashFlowRow(string myTitle, decimal? zeroMontthValue=null) : this() {
      title=myTitle;
      monthlyValue.Add(zeroMontthValue);
      totalYear1=zeroMontthValue;
      }
    }
  }
