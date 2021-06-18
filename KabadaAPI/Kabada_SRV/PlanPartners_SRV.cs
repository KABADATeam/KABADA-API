using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;
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
      is_partners_completed=pl.IsPartnersCompleted;
      
      var atri= new Plan_AttributeRepository(ctx).getPartners(planId);
      if(atri.Count<1)
        return;

      var tidi=atri.Select(x=>x.TexterId).Distinct().ToList();
      var typi=new TexterRepository(ctx).get(tidi).ToDictionary(x=>x.Id);

      KeyPartnerBase o=null;
      foreach(var a in atri){
        switch(a.Kind){
          case (short)PlanAttributeKind.keyDistributor: { var t=new PlanDistributor(); distributors.Add(t); o=t; } break;
          case (short)PlanAttributeKind.keySupplier: { var t=new PlanSupplier(); suppliers.Add(t); o=t; } break;
          case (short)PlanAttributeKind.otherKeyPartner: { var t=new PlanPartnerOther(); others.Add(t); o=t; } break;
          default: throw new Exception("wrong type attribute encountered");
          }
        o.unpack(a.AttrVal);
        o.id=a.Id;
        o.type_id=a.TexterId;
        o.type_title=typi[o.type_id].Value;
        }
       }

    }
  }
