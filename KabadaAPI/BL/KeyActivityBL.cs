using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class KeyActivityBL : UniversalAttributeBL<KeyActivityElementBL> {
    private const short KIND=(short)PlanAttributeKind.activity;

    public KeyActivityBL() : base(KIND) {}
    public KeyActivityBL(KabadaAPIdao.UniversalAttribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    }
  }
