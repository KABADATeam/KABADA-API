using KabadaAPI;
using System;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;

namespace Kabada {
  partial class PlanPartners {
    protected BLontext ctx;

    internal void read(BLontext context, Guid planId) {
      ctx=context;

      this.distributors=new List<PlanDistributor>();
      this.suppliers=new List<PlanSupplier>();
      this.others=new List<PlanPartnerOther>();

      var pl=new BusinessPlansRepository(ctx).GetPlan(planId);
      //is_partners_completed=pl.Is...;
      
      var atri= new Plan_AttributeRepository(ctx).getPartners(planId);
      if(atri.Count<1)
        return;

      KeyPartnerBase o=null;
      foreach(var a in atri){
        switch(a.Kind){
          case (short)PlanAttributeKind.keyDistributor: { var t=new PlanDistributor(); distributors.Add(t); o=t; } break;
          case (short)PlanAttributeKind.keySupplier: { var t=new PlanSupplier(); suppliers.Add(t); o=t; } break;
          case (short)PlanAttributeKind.otherKeyPartner: { var t=new PlanPartnerOther(); others.Add(t); o=t; } break;
          default: throw new Exception("wrong type attribute encountered");
          }
        }
      //var tRepo=new TexterRepository(ctx);
      //var cati=tRepo.getKeyResourceCategories().ToDictionary(x=>x.Id);
      //var typi=tRepo.getKeyResourceTypes(null).ToDictionary(x=>x.Id, x=>x.MasterId.Value);
      //foreach(var a in atri){
      //  var o=new PlanResorceWithCategory();
      //  key_resources.Add(o);
      //  var c=cati[typi[a.TexterId]];
      //  o.category=new ResourceCategory(){ id=c.Id, description=c.Value, title=c.LongValue};
      //  o.resource_id=a.Id;
      //  var w=Newtonsoft.Json.JsonConvert.DeserializeObject<PlanResource>(a.AttrVal);
      //  o.description=w.description;
      //  o.name=w.name;
      //  o.selections=w.selections;
      //  }
      }

    }
  }
