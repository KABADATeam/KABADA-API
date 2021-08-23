using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class KeyResourceBL : BAsePlan_AttributeTypedBL<KeyResourceElementBL> { // Plan_AttributeBL<KeyResourceElementBL> {
    public const short KIND=(short)PlanAttributeKind.keyResource;

    public KeyResourceBL(Guid businessPlan) : base(KIND, businessPlan) {}
   //public KeyResourceBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    public KeyResourceBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false, Guid? planForValidate=null) : base(old, forUpdate, planForValidate, KIND){}

    public KeyResourceBL(Guid byId, Plan_AttributeRepository repo, Guid? planForValidate=null) : base(byId, repo, true, planForValidate, KIND) {}

    public static KeyResourceBL Make(Guid? id, Plan_AttributeRepository repo, Guid businessPlan){
      if(id==null)
        return new KeyResourceBL(businessPlan);
       else
        return new KeyResourceBL(id.Value, repo, businessPlan);
      }
    }
  }
