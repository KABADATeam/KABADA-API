using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class ConsumerSegmentBL : CustomerSegmentBL {
    private const short KIND=(short)PlanAttributeKind.consumerSegment;

    public ConsumerSegmentBL() : base(KIND) {}
    public ConsumerSegmentBL(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    }
  }
