using System;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class RevenueStreamBL : Plan_AttributeBL<RevenueStreamElementBL> {
    public static readonly List<short> KINDs=new List<short>(){ (short)PlanAttributeKind.revenueSegment1, (short)PlanAttributeKind.revenueSegment2, (short)PlanAttributeKind.revenueOther};

    public RevenueStreamBL(short kind) : base(kind) {}
    public RevenueStreamBL(PlanAttributeKind kind) : this((short)kind) {}
    public RevenueStreamBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false) : base(old.Kind, old, forUpdate){
      if(!KINDs.Contains(kind))
        throw new Exception($"invalid renue kind={kind}");
      }
    }
  }
