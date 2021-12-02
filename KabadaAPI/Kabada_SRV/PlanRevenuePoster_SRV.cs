using KabadaAPI;
using KabadaAPIdao;
using System;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class PlanRevenuePoster {
    protected BLontext ctx;
     private short aKind { get { switch (segment)
                {
                    case 1: return (short)PlanAttributeKind.revenueSegment1;
                    case 2: return (short)PlanAttributeKind.revenueSegment2;
                    case 3: return (short)PlanAttributeKind.revenueOther;
                    default: throw new Exception("Unknown revenue streams segment");
                }
            }
        }
     private short tKind { get { return (short)EnumTexterKind.revenueStreamType; }}
     //private string packVal { get { 
     //  var w=(RevenueBase)this;
     //  var r=Newtonsoft.Json.JsonConvert.SerializeObject(this, typeof(RevenueBase), null);
     //  return r;
     //  }}
    

    internal Guid perform(BLontext context) {
      ctx=context;

      //var plan=new BusinessPlansRepository(ctx).GetPlanForUpdate(ctx.userGuid, business_plan_id); // only to validate rights on plan
      new BusinessPlansRepository(ctx).validateRW(ctx.userGuid, business_plan_id);

      if(id==null)
        return create();
      var rid=id.Value;
      using(var tr=new Transactioner(ctx)){
        var aRepo=new Plan_AttributeRepository(ctx, tr.Context);
        var o=aRepo.byId(rid, business_plan_id);
        var bo=new RevenueStreamBL(o, true);
        assign(bo);
        tr.daContext.SaveChanges();
        tr.Commit();
        //var v=packVal;
        //var changed=(o.AttrVal==v);
        //o.AttrVal=v;
        //o.TexterId = stream_type_id;
        //if(changed){
        //  aRepo.Save(o);
        //  tr.Commit();
        //  }
        }
      return rid;
      }

    private void assign(RevenueStreamBL bo){
      bo.businessPlanId=business_plan_id;
      bo.texterId=stream_type_id;
      bo.e.stream_type_id=stream_type_id;
      bo.e.price_type_id=price_type_id;
      }

    private Guid create() {
      var tp=new TexterRepository(ctx).getById(stream_type_id);
      if(tp==null || tp.Kind!=tKind)
        throw new Exception("wrong stream_type");

      
      short on=new Plan_AttributeRepository(ctx).generateAtrrOrder(business_plan_id);
      //var o=new Plan_Attribute(){ BusinessPlanId=business_plan_id, Kind=aKind, TexterId=stream_type_id, AttrVal=packVal, OrderValue=on};
      var bo=new RevenueStreamBL(aKind, business_plan_id, stream_type_id);
      //bo.businessPlanId=business_plan_id;
      //bo.texterId=stream_type_id;
      assign(bo);
      bo.orderValue=on;
      bo.unload();
      new Plan_AttributeRepository(ctx).create(bo.unload());
      return bo.id;
      //o=new Plan_AttributeRepository(ctx).Create(o);
      //return o.Id;
      }
    }
  }
