using KabadaAPI;
using System;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class PlanChannelPoster {
    protected BLontext ctx;
 //    private short aKind { get { return (short)PlanAttributeKind.channel; }}
     private short tKind { get { return (short)EnumTexterKind.channelType; }}
     //private string packVal { get { 
     //  var w=(ChannelAttribute)this;
     //  var r=Newtonsoft.Json.JsonConvert.SerializeObject(this, typeof(ChannelAttribute), null);
     //  return r;
     //  }}
    

    internal Guid perform(BLontext context) {
      ctx=context;

      new BusinessPlansRepository(ctx).getRW(business_plan_id); // only to validate rights on plan

      if(id==null)
        return create();
      var rid=id.Value;
      using(var tr=new Transactioner(ctx)){
        var aRepo=new Plan_AttributeRepository(ctx, tr.Context);
        var o=aRepo.byId(rid, business_plan_id);
        var bo=new ChannelBL(o, true);
        assign(bo);
        //var v=packVal;
        //var changed=(o.AttrVal==v);
        //o.AttrVal=v;
        //o.TexterId = channel_type_id;
        //if(changed){
        //aRepo.Save(o);
        bo.unload();
        aRepo.daContext.SaveChanges();
        tr.Commit();
//          }
        }
      return rid;
      }

    private void assign(ChannelBL that){
      that.e.channel_type_id=channel_type_id;
      that.e.channel_subtype_id=channel_subtype_id;
      that.e.subtype_type_id=subtype_type_id;
      that.e.location_type_id=location_type_id;
      that.e.product_id=product_id;
      that.e.distribution_channels_id=distribution_channels_id;    
      }

    private Guid create() {
      var tp=new TexterRepository(ctx).getById(channel_type_id);
      if(tp==null || tp.Kind!=tKind)
        throw new Exception("wrong channel_type_id");

    //  short on=new Plan_AttributeRepository(ctx).generateAtrrOrder(business_plan_id);
      //var o=new Plan_Attribute(){ BusinessPlanId=business_plan_id, Kind=aKind, AttrVal=packVal, TexterId=channel_type_id, OrderValue=on};
      //o=new Plan_AttributeRepository(ctx).Create(o);
      //return o.Id;
      var bo=new ChannelBL(business_plan_id, channel_type_id);
      assign(bo);
      new Plan_AttributeRepository(ctx).create(bo.unload());
      return bo.id;
      }
    }
  }
