using Kabada;
using System.Collections.Generic;

namespace KabadaAPI {
  public class BusinessPlanElementBL {
    public PlanStartupInvestmentBase startup;
    public List<WorkingCapitalPosterElement> working_capitals;
    public bool is_personal_characteristics_completed;

    public BusinessPlanElementBL() {
      startup=new PlanStartupInvestmentBase();
      }
    }
  }
