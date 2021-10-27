using System.Collections.Generic;

namespace Kabada {
  public partial class CashFlowRow {
    public string title;
    public List<decimal?> monthlyValue; // 0..24
    public decimal? totalYear1;
    public decimal? totalYear2;
    public decimal? postProject;
    }
  }
