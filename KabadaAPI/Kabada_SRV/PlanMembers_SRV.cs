using KabadaAPI;
using System;
using System.Linq;

namespace Kabada {
  partial class PlanMembers {
    internal void read(BLontext context, Guid planId, Guid uGuid) {
      var pl=new BusinessPlansRepository(context).getRO(planId); //GetPlan(planId, uGuid); // to validate rights
      if(pl==null)
        return;
      var mGuis=new SharedPlanRepository(context).members(planId);
      if(mGuis==null || mGuis.Count<1)
        return;
      var mUsers=new UsersRepository(context).Read(mGuis);
      members=mUsers.Select(x=>new PlanMember { user_id=x.Id, name=x.Name, surname=x.Surname, photo=x.UserPhoto, email=x.Email }).ToList();
      }
    }
  }
