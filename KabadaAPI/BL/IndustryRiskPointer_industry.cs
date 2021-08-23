using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class IndustryRiskPointer_industry : IndustryRiskPointerBL {
    public const short KIND=(short)PlanAttributeKind.industryRiskPointer_industry;

    public IndustryRiskPointer_industry() : base(KIND) {}
    public IndustryRiskPointer_industry(KabadaAPIdao.UniversalAttribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}

    public IndustryRiskPointer_industry(Guid byId, UniversalAttributeRepository repo, bool forUpdate=false) : base(byId, repo, forUpdate, KIND) {}

    public static IndustryRiskPointer_activity Make(Guid? id, UniversalAttributeRepository repo){
      if(id==null)
        return new IndustryRiskPointer_activity();
       else
        return new IndustryRiskPointer_activity(id.Value, repo);
      }
    }
  }
