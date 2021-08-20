using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class ConsumerSegmentBL : CustomerSegmentBL {
    private const short KIND=(short)PlanAttributeKind.consumerSegment;

    public ConsumerSegmentBL() : base(KIND) {}
    public ConsumerSegmentBL(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    public ConsumerSegmentBL(Guid byId, Plan_SpecificAttributesRepository repo) : base(byId, repo, KIND) {}

    public static ConsumerSegmentBL Make(Guid? id, Plan_SpecificAttributesRepository repo){
      if(id==null)
        return new ConsumerSegmentBL();
       else
        return new ConsumerSegmentBL(id.Value, repo);
      }
    }
  }
