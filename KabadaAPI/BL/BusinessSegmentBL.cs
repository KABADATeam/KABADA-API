using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class BusinessSegmentBL : CustomerSegmentBL {
    private const short KIND=(short)PlanAttributeKind.businessSegment;

    public BusinessSegmentBL() : base(KIND) {}
    public BusinessSegmentBL(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    public BusinessSegmentBL(Guid byId, Plan_SpecificAttributesRepository repo) : base(byId, repo, KIND) {}

    public static BusinessSegmentBL Make(Guid? id, Plan_SpecificAttributesRepository repo){
      if(id==null)
        return new BusinessSegmentBL();
       else
        return new BusinessSegmentBL(id.Value, repo);
      }
    }
  }
