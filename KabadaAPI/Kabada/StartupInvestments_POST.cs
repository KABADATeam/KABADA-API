using System;
using System.Collections.Generic;

namespace Kabada {
  public partial class StartupInvestments_POST : PlanStartupInvestmentBase {
    public Guid business_plan_id;
    public List<AssetPosterElement> physical_assets;
    public List<WorkingCapitalPosterElement> working_capitals;
    }
  }
