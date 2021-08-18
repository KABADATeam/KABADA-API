using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

namespace Kabada {
  partial class PlanCosts {
    protected BLontext ctx;

    internal void read(BLontext context, Guid planId) {
      ctx=context;
    
      fixed_costs = new List<Coster>();
      variable_costs = new List<Coster>();     

      var pl=new BusinessPlansRepository(ctx).GetPlan(planId, context.userGuid);
      is_cost_completed=pl.IsCostCompleted;
      
      var atri= new Plan_AttributeRepository(ctx).getCosts(planId);
      if(atri.Count<1)
        return;

      var tRepo=new TexterRepository(ctx);
      var cati=tRepo.getCostCategories().ToDictionary(x=>x.Id);
      var typi=tRepo.getCostTypes().ToDictionary(x=>x.Id);
      
      Coster o=null;
      foreach(var a in atri){
        switch(a.Kind){
          case (short)PlanAttributeKind.fixedCost: { var t=new Coster(); fixed_costs.Add(t); o=t; } break;
          case (short)PlanAttributeKind.variableCost: { var t=new Coster(); variable_costs.Add(t); o=t; } break;
          default: throw new Exception("wrong type attribute encountered");
          }
        o.unpack(a.AttrVal);
        o.id=a.Id;
        o.type_id=a.TexterId;
        o.type_title=typi[o.type_id].Value;         
        var c=cati[typi[a.TexterId].MasterId.Value];
        o.category_id = c.Id;
        o.category_title = c.Value;              
        }
       }

    }
  }
