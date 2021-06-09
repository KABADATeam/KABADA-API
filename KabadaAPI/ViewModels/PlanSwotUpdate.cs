using System;
using System.Collections.Generic;

namespace KabadaAPI.ViewModels {
  public partial class PlanSwotUpdate {
    public Guid business_plan_id { get; set; }
    public List<SwotUpdater> opportunities_threats { get; set; }
    public List<SwotUpdater> strengths_weakness { get; set; }
    }
  }
