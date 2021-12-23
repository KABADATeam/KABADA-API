using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

namespace Kabada {
  partial class PlanRevenues {
    protected BLontext ctx;

    internal void read(BLontext context, Guid planId) {
      ctx=context;
    
      segment_1 = new List<Revenue>();
      segment_2 = new List<Revenue>();     
      other = new List<Revenue>();     

      var pl=new BusinessPlansRepository(ctx).getRO(planId); //GetPlan(planId, context.userGuid);
      is_revenue_completed=pl.IsRevenueCompleted;
      
      var atri= new Plan_AttributeRepository(ctx).getRevenues(planId);
      if(atri.Count<1)
        return;

      var tRepo=new TexterRepository(ctx);
      var streams=tRepo.getRevenueStreamTypes().ToDictionary(x=>x.Id);
      var priceTypes=tRepo.getRevenuePriceMeta().ToDictionary(x=>x.Id);
      
      Revenue o=null;
      foreach(var a in atri){
        
        switch(a.Kind){
          case (short)PlanAttributeKind.revenueSegment1: { var t=new Revenue(); segment_1.Add(t); o=t; } break;
          case (short)PlanAttributeKind.revenueSegment2: { var t = new Revenue(); segment_2.Add(t); o = t; } break;
          case (short)PlanAttributeKind.revenueOther: { var t=new Revenue(); other.Add(t); o=t; } break;
          default: throw new Exception("wrong type attribute encountered");
          }
        var bo=new RevenueStreamBL(a);
        //o.unpack(a.AttrVal);
        o.id=a.Id;       
        //o.stream_type_name=streams[o.stream_type_id].Value;
        //o.price_type_name = priceTypes[o.price_type_id].Value;
        //var c=priceTypes[priceTypes[o.price_type_id].MasterId.Value];
        o.price_type_id=bo.e.price_type_id;
        o.stream_type_id=bo.e.stream_type_id;
        o.stream_type_name=streams[bo.e.stream_type_id].Value;
        o.price_type_name = priceTypes[bo.e.price_type_id].Value;
        var c=priceTypes[priceTypes[bo.e.price_type_id].MasterId.Value];
        o.price_category_id = c.Id;
        o.price_category_name = c.Value;
        o.segments=bo.e.namesOfSegments;
        }
       }

    }
  }
