using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class NgoSegmentBL : CustomerSegmentBL {
    private const short KIND=(short)PlanAttributeKind.ngoSegment;

    public NgoSegmentBL(Guid plan) : base(KIND, plan) {}
    public NgoSegmentBL(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    //public NgoSegmentBL(Guid byId, Plan_SpecificAttributesRepository repo) : base(byId, repo, KIND) {}
    public NgoSegmentBL(Guid byId, Plan_SpecificAttributesRepository repo, bool forUpdate=false, Guid? planForValidate=null)
                   : base(byId, repo, forUpdate, KIND, planForValidate) {}

    public static NgoSegmentBL Make(Guid? id, Plan_SpecificAttributesRepository repo, Guid plan){
      if(id==null)
        return new NgoSegmentBL(plan);
       else
        return new NgoSegmentBL(id.Value, repo, true, plan);
      }
    }
  }
