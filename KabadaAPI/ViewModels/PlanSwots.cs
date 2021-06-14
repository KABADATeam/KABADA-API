using System.Collections.Generic;

namespace KabadaAPI {
  public class PlanSwots {
    public bool is_swot_completed;
    public List<Swoter> strengths_weakness_items;
    public List<Swoter> oportunities_threats;

  public PlanSwots() {
    strengths_weakness_items=new List<Swoter>();
    oportunities_threats=new List<Swoter>();
    }
  }
}
