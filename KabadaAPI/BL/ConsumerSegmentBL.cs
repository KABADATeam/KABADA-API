using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class ConsumerSegmentBL : CustomerSegmentBL {
    private const short KIND=(short)PlanAttributeKind.consumerSegment;

    public ConsumerSegmentBL(Guid plan) : base(KIND, plan) {}
    public ConsumerSegmentBL(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    //public ConsumerSegmentBL(Guid byId, Plan_SpecificAttributesRepository repo) : base(byId, repo, KIND) {}
    public ConsumerSegmentBL(Guid byId, Plan_SpecificAttributesRepository repo, bool forUpdate=false, Guid? planForValidate=null)
                   : base(byId, repo, forUpdate, KIND, planForValidate) {}

    public static ConsumerSegmentBL Make(Guid? id, Plan_SpecificAttributesRepository repo, Guid plan){
      if(id==null)
        return new ConsumerSegmentBL(plan);
       else
        return new ConsumerSegmentBL(id.Value, repo, true, plan);
      }
    }
  }
