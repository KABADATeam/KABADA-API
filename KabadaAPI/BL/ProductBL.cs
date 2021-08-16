using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class ProductBL : Plan_AttributeBL<ProductElementBL> {
    private const short KIND=(short)PlanAttributeKind.product;

    public ProductBL() : base(KIND) {}
    public ProductBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    }
  }
