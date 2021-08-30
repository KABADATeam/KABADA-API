using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class KeyResourceBL : BAsePlan_AttributeTypedBL<KeyResourceElementBL> { // Plan_AttributeBL<KeyResourceElementBL> {
    public const short KIND=(short)PlanAttributeKind.keyResource;
    public const string HumanResourcesGuID="{63CEE727-8378-4603-8B0B-839751DFEED1}";
    public static Guid HID=new Guid(HumanResourcesGuID);
    public const string OwnershipType="Ownership Type";

    public KeyResourceBL(Guid businessPlan, Guid texter) : base(KIND, businessPlan, texter) {}
   //public KeyResourceBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    public KeyResourceBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false, Guid? planForValidate=null) : base(old, forUpdate, planForValidate, KIND){}

    public KeyResourceBL(Guid byId, Plan_AttributeRepository repo, Guid? planForValidate=null) : base(byId, repo, true, planForValidate, KIND) {}

    public static KeyResourceBL Make(Guid? id, Plan_AttributeRepository repo, Guid businessPlan, Guid texter, bool skipValidatePlanRights=false){
      if(skipValidatePlanRights==false)
        new BusinessPlansRepository(repo.blContext, repo.daContext).GetPlanForUpdate(repo.blContext.userGuid, businessPlan);
      if(id==null)
        return new KeyResourceBL(businessPlan, texter);
       else
        return new KeyResourceBL(id.Value, repo, businessPlan);
      }
    }
  }
