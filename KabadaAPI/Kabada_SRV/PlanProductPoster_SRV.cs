using KabadaAPI;
using KabadaAPIdao;
using System;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class PlanProductPoster {
    protected BLontext ctx;
     private short aKind { get { return (short)PlanAttributeKind.product; }}
     private short tKind { get { return (short)EnumTexterKind.productType; }}
     private string packVal { get { 
       var w=(ProductAttribute)this;
       var r=Newtonsoft.Json.JsonConvert.SerializeObject(this, typeof(ProductAttribute), null);
       return r;
       }}
    

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
        var v=packVal;
        var changed=(o.AttrVal==v);
        o.AttrVal=v;
        o.TexterId = product_type;
        if(changed){
          aRepo.Save(o);
          tr.Commit();
          }
        }
      return rid;
      }

    private Guid create() {
      var tp=new TexterRepository(ctx).getById(product_type);
      if(tp==null || tp.Kind!=tKind)
        throw new Exception("wrong product_type");

      short on=new Plan_AttributeRepository(ctx).generateAtrrOrder(business_plan_id);
      var o=new Plan_Attribute(){ BusinessPlanId=business_plan_id, Kind=aKind, AttrVal=packVal, TexterId=product_type, OrderValue=on};
      o=new Plan_AttributeRepository(ctx).create(o);
      return o.Id;
      }
    }
  }
