using KabadaAPI;
using System;

namespace Kabada {
  partial class PlanResourcePoster {
    internal Guid perform(BLontext context) {
      //var plan=new BusinessPlansRepository(context).GetPlanForUpdate(context.userGuid, business_plan_id); // only to validate rights on plan
      var repo=new Plan_AttributeRepository(context);
      var o=KeyResourceBL.Make(resource_id, repo, business_plan_id);
      assign(o);
      o.completeSet(resource_id, repo);
      return o.id;
      }

    private void assign(KeyResourceBL bo){
      //bo.businessPlanId=business_plan_id;
      bo.texterId = resource_type_id;
      bo.e.type_id=type_id;
      bo.e.name=name;
      bo.e.description=description;
      bo.e.selections=selections;
      }
    }
  }
