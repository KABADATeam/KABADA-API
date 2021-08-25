using System;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class RevenueStreamBL : BAsePlan_AttributeTypedBL<RevenueStreamElementBL> { // Plan_AttributeBL<RevenueStreamElementBL> {
    public static readonly List<short> KINDs=new List<short>(){ (short)PlanAttributeKind.revenueSegment1, (short)PlanAttributeKind.revenueSegment2, (short)PlanAttributeKind.revenueOther};

    public RevenueStreamBL(short kind, Guid plan, Guid texter) : base(kind, plan, texter) {}
    public RevenueStreamBL(PlanAttributeKind kind, Guid plan, Guid texter) : this((short)kind, plan, texter) {}
    public RevenueStreamBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false, Guid? planForValidate=null) : base(old, forUpdate, planForValidate, kindsForValidate: KINDs){}
    public RevenueStreamBL(Guid byId, Plan_AttributeRepository repo, Guid? planForValidate=null) : base(byId, repo, true, planForValidate, kindsForValidate: KINDs) {}
    }
  }
