using System;

namespace KabadaAPI.ViewModels {
  public class ChangePlanParameter {
    public Guid business_plan_id { get; set; }
    public bool is_swot_completed { get; set; }
    public bool is_resources_completed { get; set; }
  }
}
