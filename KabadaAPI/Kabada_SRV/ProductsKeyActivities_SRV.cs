using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class ProductsKeyActivities {
    internal void read(BLontext context, Guid planId) {
      var p=new BusinessPlansRepository(context).GetPlan(planId);
      is_activities_completed=p.IsActivitiesCompleted;
      var aRepo=new Plan_AttributeRepository(context);
      //var qProducts=aRepo.get(planId, Plan_AttributeRepository.PlanAttributeKind.product);
      var prodi=aRepo.get(planId, Plan_AttributeRepository.PlanAttributeKind.product);
      if(prodi.Count<1)
        return;
      products=prodi.Select(x=>new ProductBL(x)).Select(y=>new  ProductKeyActivities { id=y.id, title=y.e.title}).ToList();
      var idi=products.Select(x=>(Guid?)x.id).ToList();
      var d=products.ToDictionary(x=>x.id);
      var txi=new TexterRepository(context).getActivitiesTypesQ().ToDictionary(x=>x.Id);
      var acti=new UniversalAttributeRepository(context).byMasters(idi).Select(x=>new KeyActivityBL(x)).ToList();
      foreach(var a in acti){
        var t=d[a.masterId.Value];
        if(t.activities==null)
          t.activities=new List<ProductKeyActivity>();
        var su=txi[a.categoryId.Value];
        var ty=txi[su.MasterId.Value];
        var an=new ProductKeyActivity(){ id=a.id, sub_type_id=su.Id, sub_type_name=su.Value, type_id=ty.Id, type_name=ty.Value, name=a.e.name, description=a.e.description };
        t.activities.Add(an);
        }
      }
    }
  }

