using KabadaAPI;
using System;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class PlanCostPoster {
    protected BLontext ctx;
     private string packVal { get { 
       var w=(CostBase)this;
       var r=Newtonsoft.Json.JsonConvert.SerializeObject(this, typeof(CostBase), null);
       return r;
       }}
    
     private void assign(CostBL bo){
       bo.e.name=name;
       bo.e.description=description;
       bo.texterId=type_id;
       }

    internal Guid perform(BLontext context, Plan_AttributeRepository.PlanAttributeKind aKind, EnumTexterKind tKind) {
      ctx=context;

      //var plan=new BusinessPlansRepository(ctx).GetPlanForUpdate(ctx.userGuid, business_plan_id); // only to validate rights on plan
      new BusinessPlansRepository(ctx).validateRW(ctx.userGuid, business_plan_id);

      if(id==null)
        return create(aKind, tKind);
      var rid=id.Value;
      using(var tr=new Transactioner(ctx)){
        var aRepo=new Plan_AttributeRepository(ctx, tr.Context);
        var o=aRepo.byId(rid, business_plan_id);
        var bo=new CostBL(o, true);
        assign(bo);
        bo.unload();
        tr.daContext.SaveChanges();
        tr.Commit();
        //var v=packVal;
        //var changed=(o.AttrVal==v);
        //o.AttrVal=v;
        //if(changed){
        //  aRepo.Save(o);
        //  tr.Commit();
        //  }
        }
      return rid;
      }

    private Guid create(Plan_AttributeRepository.PlanAttributeKind aKind, EnumTexterKind tKind) {
      var tp=new TexterRepository(ctx).getById(type_id);
      if(tp==null || tp.Kind!=(short)tKind)
        throw new Exception("wrong cost_type");

      short on=new Plan_AttributeRepository(ctx).generateAtrrOrder(business_plan_id);
      var bo=new CostBL(aKind, business_plan_id, type_id){ orderValue=on };
      assign(bo);
      //var o=new KabadaAPIdao.Plan_Attribute(){ BusinessPlanId=business_plan_id, Kind=(short)aKind, TexterId=type_id, AttrVal=packVal, OrderValue=on};
      new Plan_AttributeRepository(ctx).create(bo.unload());
      return bo.id;
      }
    }
  }
