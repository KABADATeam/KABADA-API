using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class NgoSegmentBL : CustomerSegmentBL {
    private const short KIND=(short)PlanAttributeKind.ngoSegment;

    public NgoSegmentBL() : base(KIND) {}
    public NgoSegmentBL(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    }
  }
