using KabadaAPI;
using System;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;

namespace Kabada {
  partial class CustomerSegments {
     protected BLontext ctx;

    internal void read(BLontext context, Guid planId) {
      ctx=context;
 
      var pl=new BusinessPlansRepository(ctx).GetPlan(planId, context.userGuid);
      is_customer_segments_completed=pl.IsCustomerSegmentsCompleted;
      
      var atri= new Plan_SpecificAttributesRepository(ctx).getSegments(planId);
      if(atri.Count<1)
        return;

      consumers=new List<ConsumerSegment>();
      business=new List<BusinessSegment>();
      public_bodies_ngo=new List<NgoSegment>();

      var codes=new TexterRepository(ctx).getCustomerSegmentsCodifiers();

      CustomerSegment o=null;
      foreach(var a in atri){
        switch(a.Kind){
          case (short)PlanAttributeKind.consumerSegment: { var t=new ConsumerSegment(); consumers.Add(t); o=t; } break;
          case (short)PlanAttributeKind.businessSegment: { var t=new BusinessSegment(); business.Add(t); o=t; } break;
          case (short)PlanAttributeKind.ngoSegment: { var t=new NgoSegment(); public_bodies_ngo.Add(t); o=t; } break;
          default: throw new Exception("wrong type attribute encountered");
          }
        o.id=a.Id;
        o.comment=a.Comment;
        var w=Newtonsoft.Json.JsonConvert.DeserializeObject<CustomerSegmentElementBL>(a.AttrVal);
        o.unpack(w, codes);
        }
       }
    }
  }
