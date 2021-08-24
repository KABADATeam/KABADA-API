using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class ProductBL : BAsePlan_AttributeTypedBL<ProductElementBL> { //Plan_AttributeBL<ProductElementBL> {
    private const short KIND=(short)PlanAttributeKind.product;

    public ProductBL() : base(KIND) {}
    public ProductBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false) : base(old, forUpdate, kindForValidate: KIND){}

    public ProductBL(Guid byId, Plan_AttributeRepository repo, Guid? planForValidate=null) : base(byId, repo, true, planForValidate, KIND) {}
    }
  }
