using KabadaAPI;
using Newtonsoft.Json;
using System;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class CustomerRelationshipPOST {
    protected BLontext ctx;
    private string packVal { get {
      return Newtonsoft.Json.JsonConvert.SerializeObject(channels, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
      }}

    internal Guid perform(BLontext context) {
      ctx=context;

      new BusinessPlansRepository(ctx).getRW(business_plan_id);  // only to validate rights on plan

      if(item_id==null)
        return create();
      var rid=item_id.Value;
      using(var tr=new Transactioner(ctx)){
        var aRepo=new Plan_AttributeRepository(ctx, tr.Context);
        var o=aRepo.byId(rid, business_plan_id);
        var v=packVal;
        var changed=(o.AttrVal==v);
        o.AttrVal=v;
        if(changed){
          aRepo.Save(o);
          tr.Commit();
          }
        }
      return rid;
      }

    private Guid create() {
      var tk=(short)EnumTexterKind.action;
      var tp=new TexterRepository(ctx).getById(category_id);
      if(tp==null || tp.Kind!=tk)
        throw new Exception("wrong resource_type");

      short on=new Plan_AttributeRepository(ctx).generateAtrrOrder(business_plan_id);
      var aKind=(short)PlanAttributeKind.relationshipActivity1 +group-1;
      var o=new KabadaAPIdao.Plan_Attribute(){ BusinessPlanId=business_plan_id, Kind=(short)aKind, TexterId=category_id, AttrVal=packVal, OrderValue=on, Id=Guid.NewGuid() };
      o=new Plan_AttributeRepository(ctx).create(o);
      return o.Id;
      }
    }
  }
