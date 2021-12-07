using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class KeyResourceBL : BAsePlan_AttributeTypedBL<KeyResourceElementBL> { // Plan_AttributeBL<KeyResourceElementBL> {
    public const short KIND=(short)PlanAttributeKind.keyResource;
    public const string HumanResourcesGuID="{63CEE727-8378-4603-8B0B-839751DFEED1}";
    public static Guid HID=new Guid(HumanResourcesGuID);
    public const string PhysicalResourcesGuID="{B3EF13CF-C5F0-46D9-BA7B-79AB2147EFFB}";
    public static Guid PID=new Guid(PhysicalResourcesGuID);
    public const string IntelectualResourcesGuID="{D938DD78-01A5-4D06-9757-149402DB6E7D}";
    public static Guid IID=new Guid(IntelectualResourcesGuID);
    public const string OwnershipType="Ownership type";
    public const string Frequency="Frequency";
    public const string SalaryGuIDvariable="{c7b32094-6538-4e72-ad49-6ea1fda21562}";
    public static Guid SVID=new Guid(SalaryGuIDvariable);
    public const string SalaryGuIDfixed="{f5d95c3b-4894-41b1-98b8-b1eb44ef436a}";
    public static Guid SFID=new Guid(SalaryGuIDfixed);

    public KeyResourceBL(Guid businessPlan, Guid texter) : base(KIND, businessPlan, texter) {}
   //public KeyResourceBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    public KeyResourceBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false, Guid? planForValidate=null) : base(old, forUpdate, planForValidate, KIND){}

    public KeyResourceBL(Guid byId, Plan_AttributeRepository repo, Guid? planForValidate=null) : base(byId, repo, true, planForValidate, KIND) {}

    public static KeyResourceBL Make(Guid? id, Plan_AttributeRepository repo, Guid businessPlan, Guid texter, bool skipValidatePlanRights=false){
      if(skipValidatePlanRights==false)
        new BusinessPlansRepository(repo.blContext, repo.daContext).getRW(businessPlan);
      if(id==null)
        return new KeyResourceBL(businessPlan, texter);
       else
        return new KeyResourceBL(id.Value, repo, businessPlan);
      }
    }
  }
