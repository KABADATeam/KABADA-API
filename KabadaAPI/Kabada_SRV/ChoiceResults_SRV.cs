﻿using KabadaAPI;
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
      //var plan=bRepo.GetPlanForUpdate(ctx.userGuid, plan_id); // to validate rights
      var plan=new BusinessPlansRepository(ctx).getRW(plan_id);
      if(plan==null || plan.UserId!=ctx.userGuid)
        throw new Exception("not owner");

      var paRepo=new Plan_SpecificAttributesRepository(ctx, bRepo.daContext);
      var o=paRepo.personalChar(plan_id);
      PersonalCharBL kri=null;
      if(o==null)
        kri=new PersonalCharBL(plan_id);
       else
        kri=new PersonalCharBL(o, true);
      kri.e.Clear();
      foreach(var x in this.choices)
        kri.e.Add(x);
      kri.unload();
      kri.completeSet(o==null?null:kri.id, paRepo);
      }
    }
  }
