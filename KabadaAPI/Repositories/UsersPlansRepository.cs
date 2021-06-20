using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public class UsersPlansRepository : BaseRepository
    {
      public UsersPlansRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

        public List<BusinessPlan> GetPlans(Guid userId)
        {
            var pp = daContext.BusinessPlans.Include(x => x.User);
            var myPlans = pp.Where(x => x.User.Id.Equals(userId)).ToList();
            var shp = daContext.SharedPlans.Where(x => x.UserId.Equals(userId));            
            var sharedPlans = from sh in shp
                      join bp in pp on sh.BusinessPlanId equals bp.Id 
                      select bp;
            return myPlans.Concat(sharedPlans).ToList();          
        }

        public BusinessPlan Save(Guid userId, string title, Guid activityId, Guid langId, Guid? imgId, Guid? countryId)
        {
            //User user = context.Users.Include(x => x.BusinessPlans).FirstOrDefault(i => i.Id.Equals(userId));
            var user = daContext.Users.FirstOrDefault(i => i.Id.Equals(userId));
            var activity = daContext.Activities.FirstOrDefault(i => i.Id.Equals(activityId));
            var country = daContext.Countries.FirstOrDefault(i => i.Id.Equals(countryId));
            var language = daContext.Languages.FirstOrDefault(i => i.Id.Equals(langId));
            var image = daContext.UserFiles.FirstOrDefault(i => i.Id.Equals(imgId)&&i.UserId.Equals(userId));
            if (imgId!=null&&image == null) new Exception("Can't find the image specified");
            BusinessPlan plan = new BusinessPlan()
            {
                Title = title,
                Activity = activity,
                Country = country,
                Language = language,
                Img = imgId,
                User = user,
                Created = DateTime.Now
            };

            daContext.BusinessPlans.Add(plan);
            return plan;
        }

        public void Remove(Guid userId, Guid planId)
        {            
            BusinessPlan businessPlan = daContext.BusinessPlans.FirstOrDefault(i => i.Id.Equals(planId));
            daContext.BusinessPlans.Remove(businessPlan);
            daContext.SaveChanges();
           // return plan;
        }

        public BusinessPlan GetSelectedPlan(Guid userId, Guid planId)
        {
            BusinessPlan businessPlan = daContext.BusinessPlans.FirstOrDefault(i => i.Id.Equals(planId));
            if (businessPlan != null)
            {
                return businessPlan;
            }
            else
                throw new Exception("Plan was not found");            
        }
    }
}