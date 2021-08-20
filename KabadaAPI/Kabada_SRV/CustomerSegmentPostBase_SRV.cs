using KabadaAPI;
using KabadaAPIdao;
using System;
using System.Collections.Generic;

namespace Kabada {
  partial class CustomerSegmentPostBase {
    //protected BLontext ctx;
 
    //public virtual Guid perform(BLontext context, short kind){
    //  ctx=context;
    // var plan=new BusinessPlansRepository(ctx).GetPlanForUpdate(ctx.userGuid, business_plan_id); // only to validate rights on plan
    //  var t=new CustomerSegmentElementBL();
    //  fill(t);
    //  var val=t.pack();
 
    //  if(id==null)
    //    return create(kind, val);
    //  var rid=id.Value;
    //  using(var tr=new Transactioner(ctx)){
    //    var aRepo=new Plan_SpecificAttributesRepository(ctx, tr.Context);
    //    var o=aRepo.byId(rid, business_plan_id, kind);
    //    var changed=(o.AttrVal==val);
    //    o.AttrVal=val;
    //    if(comment!=o.Comment){
    //      changed=true;
    //      o.Comment=comment;
    //      }
    //    if(changed){
    //      aRepo.Save(o);
    //      tr.Commit();
    //      }
    //    }
    //  return rid;
    //  }

    //private Guid create(short aKind, string packVal) {
    //  short on=new Plan_SpecificAttributesRepository(ctx).generateAtrrOrder(business_plan_id);
    //  var o=new Plan_SpecificAttribute(){ BusinessPlanId=business_plan_id, Kind=aKind, AttrVal=packVal, OrderValue=on, Comment=comment };
    //  o=new Plan_SpecificAttributesRepository(ctx).create(o);
    //  return o.Id;
    //  }

    protected virtual void fill(CustomerSegmentElementBL t) { throw new NotImplementedException(); }

    protected virtual void fill(CustomerSegmentElementBL t, TexterRepository.EnumTexterKind texterKind, List<Guid> contents) { 
      if(contents!=null && contents.Count>0)
        t.minorAttributes.Add((short)texterKind, contents); 
      }

    public virtual Guid perform(BLontext context, short kind){
      var ctx=context;
      var plan=new BusinessPlansRepository(ctx).GetPlanForUpdate(ctx.userGuid, business_plan_id); // only to validate rights on plan
      using(var tr=new Transactioner(ctx)){
        var aRepo=new Plan_SpecificAttributesRepository(ctx, tr.Context);
        var o=CustomerSegmentBL.Make(kind, id, aRepo);
        assign(o);
        o.completeSet(id, aRepo);
        tr.Commit();
        return o.id;
        }
      }


    private void assign(CustomerSegmentBL bo){
      bo.businessPlanId=business_plan_id;
      bo.e.minorAttributes=new Dictionary<short, List<Guid>>();
      fill(bo.e);
      }
    

    }
  }
