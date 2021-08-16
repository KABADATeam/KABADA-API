using KabadaAPI;
using KabadaAPIdao;
using System;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class PlanResourcePoster {
    protected BLontext ctx;
     private short aKind { get { return (short)PlanAttributeKind.keyResource; }}
     private short tKind { get { return (short)EnumTexterKind.keyResourceType; }}
     private string packVal { get { 
       var w=(PlanResource)this;
       var r=Newtonsoft.Json.JsonConvert.SerializeObject(this, typeof(PlanResource), null);
       return r;
       }}

    private void assign(KeyResourceBL bo){
      bo.e.type_id=type_id;
      bo.e.name=name;
      bo.e.description=description;
      bo.e.selections=selections;
      bo.texterId = resource_type_id;
      }

    internal Guid perform(BLontext context) {
      ctx=context;

      var plan=new BusinessPlansRepository(ctx).GetPlanForUpdate(ctx.userGuid, business_plan_id); // only to validate rights on plan

      if(resource_id==null)
        return create();
      var rid=resource_id.Value;
      using(var tr=new Transactioner(ctx)){
        var aRepo=new Plan_AttributeRepository(ctx, tr.Context);
        var o=aRepo.byId(rid, business_plan_id);
        var bo=new KeyResourceBL(o, true);
        assign(bo);
        tr.daContext.SaveChanges();
        //var v=packVal;
        //var changed=(o.AttrVal==v);
        //o.AttrVal=v;
        //    o.TexterId = resource_type_id;
        //if(changed){
          //aRepo.Save(o);
          tr.Commit();
          //}
        }
      return rid;
      }

    private Guid create() {
      var tp=new TexterRepository(ctx).getById(resource_type_id);
      if(tp==null || tp.Kind!=tKind)
        throw new Exception("wrong resource_type");

      short on=new Plan_AttributeRepository(ctx).generateAtrrOrder(business_plan_id);
      var bo=new KeyResourceBL();
      bo.businessPlanId=business_plan_id;
      //bo.texterId=resource_type_id;
      bo.orderValue=on;
      assign(bo);
      //var o=new Plan_Attribute(){ BusinessPlanId=business_plan_id, Kind=aKind, TexterId=resource_type_id, AttrVal=packVal, OrderValue=on};
      new Plan_AttributeRepository(ctx).Create(bo.unload());
      return bo.id;
      }
    }
  }
