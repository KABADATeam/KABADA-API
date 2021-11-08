using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class IndustryRisk {
    protected List<IndustryRiskCategoryType> CategoryTypes = new List<IndustryRiskCategoryType>()
    {
        new IndustryRiskCategoryType(){category="MACRO",type="Political and legal"},
        new IndustryRiskCategoryType(){category="MACRO",type="Economic"},
        new IndustryRiskCategoryType(){category="MACRO",type="Social"},
        new IndustryRiskCategoryType(){category="MACRO",type="Technological"},
        new IndustryRiskCategoryType(){category="MACRO",type="Environmental"},

        new IndustryRiskCategoryType(){category="INDUSTRY",type="Existing competition"},  
        new IndustryRiskCategoryType(){category="INDUSTRY",type="Potential competition"},
        new IndustryRiskCategoryType(){category="INDUSTRY",type="Substitution possibilities"},
        new IndustryRiskCategoryType(){category="INDUSTRY",type="Power of suppliers"},
        new IndustryRiskCategoryType(){category="INDUSTRY",type="Power of buyers"},

        new IndustryRiskCategoryType(){category="COMPANY",type="Resources: Human"},
        new IndustryRiskCategoryType(){category="COMPANY",type="Resources: Tangible"},
        new IndustryRiskCategoryType(){category="COMPANY",type="Processes"}
    };
    public void validate(){ // errors bring exception
        // category+type allowed combination
        if (!CategoryTypes.Any(o => o.category == category && o.type == type)) throw new Exception("Category+type is out of allowed combinations");
        // likelihood and severity range [1..3]
        if (likelihood!=null&&(likelihood < 1 || likelihood > 3)) throw new Exception("Likelihood value is out of range [1..3]");
        if (severity!=null&&(severity < 1 || severity > 3)) throw new Exception("Severity value is out of range [1..3]");
      }
    }
  }
