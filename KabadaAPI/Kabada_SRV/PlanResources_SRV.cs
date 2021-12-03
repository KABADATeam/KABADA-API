using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class PlanResources {
    protected BLontext ctx;
    internal void read(BLontext context, Guid planId) {
      ctx=context;

      key_resources=new List<PlanResorceWithCategory>();

      var pl=new BusinessPlansRepository(ctx).getRO(planId); //GetPlan(planId, context.userGuid);
      is_resources_completed=pl.IsResourcesCompleted;
      
      var atri= new Plan_AttributeRepository(ctx).getResources(planId);
      if(atri.Count<1)
        return;

      var tRepo=new TexterRepository(ctx);
      var cati=tRepo.getKeyResourceCategories().ToDictionary(x=>x.Id);
      var typi=tRepo.getKeyResourceTypes(null).ToDictionary(x=>x.Id, x=>x.MasterId.Value);
      foreach(var a in atri){
        var bo=new KeyResourceBL(a);
        var o=new PlanResorceWithCategory();
        key_resources.Add(o);
        var c=cati[typi[bo.texterId]];
        o.category=new ResourceCategory(){ id=c.Id, description=c.Value, title=c.LongValue};
        o.resource_id=bo.id;
        //var w=Newtonsoft.Json.JsonConvert.DeserializeObject<PlanResource>(a.AttrVal);
        o.description=bo.e.description;
        o.name=bo.e.name;
        o.type_id = bo.texterId;
        if(bo.e.selections!=null){
          o.selections=new List<ResourceSelection>();
          foreach(var x in bo.e.selections){
            var t=new ResourceSelection(){ title=x.title };
            o.selections.Add(t);
            if(x.options!=null && x.options.Count>0){
              t.options=x.options.Select(y=>new ResourceOption { title=y }).ToList();
              t.options[x.selected].selected=true;
              }
            }
          }
        }
      }
    }
  }
