using KabadaAPI;
using System;
using System.Linq;

namespace Kabada {
  partial class ProductsKeyActivities {
    internal void read(BLontext context, Guid planId) {
      var p=new BusinessPlansRepository(context).GetPlan(planId);
      is_activities_completed=p.IsActivitiesCompleted;
      var prodi=new Plan_AttributeRepository(context).get(planId, Plan_AttributeRepository.PlanAttributeKind.product);
      if(prodi.Count<1)
        return;
      var acti=new UniversalAttributeRepository(context).byMasters(prodi.Select(x=>(Guid?)x.Id).ToList()).GroupBy(x=>x.MasterId).ToDictionary(g=>g.Key, g=>g.ToList());
      throw new NotImplementedException();
      }
    }
  }
