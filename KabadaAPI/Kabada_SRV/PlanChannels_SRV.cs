using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

namespace Kabada {
  partial class PlanChannels {
    protected BLontext ctx;

        internal void read(BLontext context, Guid planId)
        {
            ctx = context;
            channels = new List<PlanChannel>();
            //segment_1 = new List<Revenue>();
            //segment_2 = new List<Revenue>();     
            //other = new List<Revenue>();     

            var pl = new BusinessPlansRepository(ctx).GetPlan(planId);
            is_channels_completed = pl.IsChannelsCompleted;

            var atri = new Plan_AttributeRepository(ctx).getChannels(planId);
            if (atri.Count < 1)
                return;

            var tRepo = new TexterRepository(ctx);
            var types = tRepo.getChannelTypesMeta().ToDictionary(x => x.Id);
            //var products=tRepo.ge

            ChannelAttribute ch = new ChannelAttribute();
            foreach (var a in atri) {
              var ba=new ChannelBL(a);
                var o = new PlanChannel(); channels.Add(o);
              ch=ba.e;
                //ch.unpack(a.AttrVal);
                o.id = a.Id;
                o.channel_type = new ChannelBase();
                
                o.channel_type.id = a.TexterId;
                o.channel_type.name = types[a.TexterId].Value;
                if (ch.channel_subtype_id != null) {
                    o.channel_subtype = new PlanChannelSubtype(){id = ch.channel_subtype_id.Value,name = types[ch.channel_subtype_id.Value].Value };
                    if (ch.subtype_type_id != null) { 
                        o.channel_subtype.type = new PlanChannelSubtypeType() { id = ch.subtype_type_id.Value, name = types[ch.subtype_type_id.Value].Value, location_type_id=ch.location_type_id };
                    }
                }
                if (ch.distribution_channels_id.Count > 0)
                {
                    o.distribution_channels = new List<ChannelBase>();
                    foreach (var d in ch.distribution_channels_id) {
                        o.distribution_channels.Add(new ChannelBase() { id = d, name = types[d].Value });
                    }
                }
                o.products = new List<ChannelBase>();
                foreach (var p in ch.product_id)
                {
                    var r = new Plan_AttributeRepository(context).byId(p);
                    var pr = new ProductAttribute(); pr.unpack(r.AttrVal);
                    
                    o.products.Add(new ChannelBase() { id = p, name = pr.title });
                }

            }
        }
    }
  }
