using System.Collections.Generic;

namespace KabadaAPI {
  public class Plan_OwnMoney : FinancialInvestment {
    public Plan_OwnMoney(string title, short? period, List<decimal?> list) : base(title, period,list) {}
    }
  }
