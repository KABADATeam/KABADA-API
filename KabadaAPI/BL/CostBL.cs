using System;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class CostBL : Plan_AttributeBL<CostElementBL> {
    public static readonly List<short> KINDs=new List<short>(){ (short)PlanAttributeKind.fixedCost, (short)PlanAttributeKind.variableCost};

    public CostBL(short kind) : base(kind) {}
    public CostBL(PlanAttributeKind kind) : this((short)kind) {}
    public CostBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false) : base(old.Kind, old, forUpdate){
      if(!KINDs.Contains(kind))
        throw new Exception($"invalid renue kind={kind}");
      }
    }
  }
