using System;

namespace Kabada {
  public class ChangePlanParameter {
    public Guid business_plan_id { get; set; }
    public bool is_swot_completed { get; set; }
    public bool is_resources_completed { get; set; }
    public bool is_partners_completed { get; set; }
    public bool is_proposition_completed { get; set; }
    public bool is_cost_completed { get; set; }
    public bool is_revenue_completed { get; set; }
    public bool is_channels_completed { get; set; }
    }
}
