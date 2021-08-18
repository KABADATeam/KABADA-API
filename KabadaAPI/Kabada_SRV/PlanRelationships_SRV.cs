using KabadaAPI;
using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

namespace Kabada {
  partial class PlanRelationships {
    private BLontext ctx;

    internal void read(BLontext context, Guid planId) {
      ctx=context;

      var pl=new BusinessPlansRepository(ctx).GetPlan(planId, context.userGuid);
      is_customer_relationship_completed=pl.IsCustomerRelationshipCompleted;
      
      var aRepo= new Plan_AttributeRepository(ctx);

      var tRepo=new TexterRepository(ctx);
      var acti=tRepo.getCustomerRelationshipActions().ToDictionary(x=>x.Id);

      how_to_get_new=readS(aRepo,acti, planId, PlanAttributeKind.relationshipActivity1);
      how_to_keep_existing=readS(aRepo,acti, planId, PlanAttributeKind.relationshipActivity2);
      how_to_make_spend=readS(aRepo,acti, planId, PlanAttributeKind.relationshipActivity3);
      }

    private List<PlanRelationship> readS(Plan_AttributeRepository aRepo, Dictionary<Guid, Texter> acti, Guid planId,PlanAttributeKind aKind) {
      var atri=aRepo.get(planId, aKind);
      if(atri.Count<1)
        return null;
      var r=new List<PlanRelationship>();
      Texter act=null;
      foreach(var a in atri){
        var o=new PlanRelationship();
        r.Add(o);
        o.id=a.Id;
        if(acti.TryGetValue(a.TexterId,out act))
          o.category=new Codifier(){ id=act.Id, title=act.Value };
        o.channels=Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(a.AttrVal);
        }
      return r;
      }
    }
  }
