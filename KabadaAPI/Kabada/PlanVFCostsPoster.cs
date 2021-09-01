using System;
using System.Collections.Generic;

namespace Kabada {
  public partial class PlanVFCostsPoster {
    public Guid business_plan_id;
    public List<CategorizedCosts> @fixed;
    public List<CategorizedCosts> @variable;
    }
  }
