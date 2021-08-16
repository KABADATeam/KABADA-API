using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class BusinessSegmentBL : CustomerSegmentBL {
    private const short KIND=(short)PlanAttributeKind.businessSegment;

    public BusinessSegmentBL() : base(KIND) {}
    public BusinessSegmentBL(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    }
  }
