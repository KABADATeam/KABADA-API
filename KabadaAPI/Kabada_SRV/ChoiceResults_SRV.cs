using KabadaAPI;
using System;

namespace Kabada {
  partial class ChoiceResults {

    internal void read(BLontext context, Guid planId) {
      plan_id=planId;
      var p=new BusinessPlansRepository(context).GetPlan(planId, context.userGuid);
      if(p==null)
        throw new Exception("access prohibited");
      var a=new Plan_SpecificAttributesRepository(context).personalChar(planId);
      if(a!=null){
        var bo=new PersonalCharBL(a);
        foreach(var o in bo.e)
          this.Add(o);
        }
      }

    internal void perform(BLontext ctx) {
      var bRepo=new BusinessPlansRepository(ctx);
      var plan=bRepo.GetPlanForUpdate(ctx.userGuid, plan_id); // to validate rights
      if(plan.User.Id!=ctx.userGuid)
        throw new Exception("not owner");

      var paRepo=new Plan_SpecificAttributesRepository(ctx, bRepo.daContext);
      var kri=PersonalCharBL.Make(paRepo, plan_id);
      kri.e.Clear();
      foreach(var x in this.choices)
        kri.e.Add(x);
      kri.unload();
      bRepo.daContext.SaveChanges();
      }
    }
  }
