using System;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class CostBL : BAsePlan_AttributeTypedBL<CostElementBL> { // Plan_AttributeBL<CostElementBL> {
    public static readonly List<short> KINDs=new List<short>(){ (short)PlanAttributeKind.fixedCost, (short)PlanAttributeKind.variableCost};

    public CostBL(short kind, Guid plan, Guid texter) : base(kind, plan, texter) {}
    public CostBL(PlanAttributeKind kind, Guid plan, Guid texter) : this((short)kind, plan, texter) {}
    public CostBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false, Guid? planForValidate=null) : base(old, forUpdate, planForValidate, kindsForValidate: KINDs){}
    public CostBL(Guid byId, Plan_AttributeRepository repo, Guid? planForValidate=null) : base(byId, repo, true, planForValidate, kindsForValidate: KINDs) {}
    }
  }
