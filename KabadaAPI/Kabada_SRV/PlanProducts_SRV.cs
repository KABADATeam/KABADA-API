using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class PlanProducts {
    protected BLontext ctx;

    internal void read(BLontext context, Guid planId) {
      ctx=context;

      this.products=new  List<ProductReport>();

      var pl=new BusinessPlansRepository(ctx).GetPlan(planId);
      // TODO this.is_proposition_completed=pl.IsPropositionCompleted;
      
      var atri= new Plan_AttributeRepository(ctx).getProducts(planId);
      if(atri.Count<1)
        return;

      var tidi=atri.Select(x=>x.TexterId).Distinct().ToList();
      var typi=new TexterRepository(ctx).get(tidi).ToDictionary(x=>x.Id);

      ProductReport o=null;
      foreach(var a in atri){
        o=new ProductReport(); products.Add(o);
        o.unpack(a.AttrVal);
        o.id=a.Id;
        o.product_type=typi[a.TexterId].Value;
        }
      }
    }
  }
