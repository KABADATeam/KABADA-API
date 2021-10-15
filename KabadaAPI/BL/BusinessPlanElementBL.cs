using Kabada;
using System.Collections.Generic;

namespace KabadaAPI {
  public class BusinessPlanElementBL {
    public PlanStartupInvestmentBase startup;
    public List<WorkingCapitalPosterElement> working_capitals;

    public BusinessPlanElementBL() {
      startup=new PlanStartupInvestmentBase();
      }
    }
  }
