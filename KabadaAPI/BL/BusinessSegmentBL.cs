using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class BusinessSegmentBL : CustomerSegmentBL {
    private const short KIND=(short)PlanAttributeKind.businessSegment;

    public BusinessSegmentBL(Guid plan) : base(KIND, plan) {}
    public BusinessSegmentBL(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    public BusinessSegmentBL(Guid byId, Plan_SpecificAttributesRepository repo, bool forUpdate=false, Guid? planForValidate=null)
                   : base(byId, repo, forUpdate, KIND, planForValidate) {}

    public static BusinessSegmentBL Make(Guid? id, Plan_SpecificAttributesRepository repo, Guid plan){
      if(id==null)
        return new BusinessSegmentBL(plan);
       else
        return new BusinessSegmentBL(id.Value, repo, true, plan);
      }
    }
  }
