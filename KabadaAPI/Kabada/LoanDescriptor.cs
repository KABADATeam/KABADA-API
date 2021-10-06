using System.Collections.Generic;

namespace Kabada {
  public class LoanDescriptor {
    public string title;
    public short payment_period;
    public decimal interest_rate;
    public short grace_period;
    public short start_month;
    public List<decimal?> investment_amounts;
    }
  }
