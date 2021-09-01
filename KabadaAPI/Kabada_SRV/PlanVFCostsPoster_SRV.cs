using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class PlanVFCostsPoster {
    internal void perform(BLontext context) {
      var tsks=new List<TypedCost>();
      collect(tsks, @fixed);
      collect(tsks, @variable);
      if(tsks.Count<1)
        return;
      using(var tr=new Transactioner(context)){
        var ctx=tr.Context;
        var obi=new Plan_AttributeRepository(context, ctx).getCosts(business_plan_id).ToDictionary(x=>x.Id);
        foreach(var x in tsks){
          var bo=new CostBL(obi[x.id], true);
          bo.e.vat=x.vat;
          bo.e.price=x.price;
          bo.e.first_expenses=x.first_expenses;
          bo.unload();
          }
        ctx.SaveChanges();
        tr.Commit();
        }
      }

    private void collect(List<TypedCost> tsks, List<CategorizedCosts> set) {
      if(set==null)
        return;
      foreach(var x in set)
        tsks.AddRange(x.types);
      }
    }
  }
