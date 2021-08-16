using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class KeyResourceBL : Plan_AttributeBL<KeyResourceElementBL> {
    public const short KIND=(short)PlanAttributeKind.keyResource;

    public KeyResourceBL() : base(KIND) {}
    public KeyResourceBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    }
  }
