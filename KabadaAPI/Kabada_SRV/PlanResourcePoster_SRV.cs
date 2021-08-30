using KabadaAPI;
using System;
using System.Linq;

namespace Kabada {
  partial class PlanResourcePoster {
    internal Guid perform(BLontext context) {
      //var plan=new BusinessPlansRepository(context).GetPlanForUpdate(context.userGuid, business_plan_id); // only to validate rights on plan
      var repo=new Plan_AttributeRepository(context);
      var o=KeyResourceBL.Make(resource_id, repo, business_plan_id, resource_type_id);
      assign(o);
      o.completeSet(resource_id, repo);
      return o.id;
      }

    private void assign(KeyResourceBL bo){
      //bo.businessPlanId=business_plan_id;
      //bo.texterId = resource_type_id;
      bo.e.type_id=type_id;
      bo.e.name=name;
      bo.e.description=description;
      if(selections==null || selections.Count<1)
        return;
      var d=selections.ToDictionary(x=>x.title); // validate uniqueness of titles
      bo.e.selections=new System.Collections.Generic.List<ResourceSelectionBL>();
      foreach(var s in selections){
        var t=new ResourceSelectionBL(){ title=s.title} ;
        bo.e.selections.Add(t);
        if(s.options!=null && s.options.Count>0){
          t.options=s.options.Select(x=>x.title).ToList();
          for(var i=s.options.Count; i>0; i--){
            if(s.options[i-1].selected){
              t.selected=(short)(i-1);
              break;
              }
            }
          }
        }
      }
    }
  }
