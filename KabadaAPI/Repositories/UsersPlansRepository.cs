using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public class UsersPlansRepository : BaseRepository
    {
      public UsersPlansRepository(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger =null) : base(configuration, logger) { }

        public List<BusinessPlan> GetPlans(Guid userId)
        {
            var pp = context.BusinessPlans.Include(x => x.User);
            var myPlans = pp.Where(x => x.User.Id.Equals(userId)).ToList();
            var shp = context.SharedPlans.Where(x => x.UserId.Equals(userId));            
            var sharedPlans = from sh in shp
                      join bp in pp on sh.BusinessPlanId equals bp.Id 
                      select bp;
            return myPlans.Concat(sharedPlans).ToList();          
        }

        public BusinessPlan Save(Guid userId, string title, Guid activityId, Guid countryId)
        {
            //User user = context.Users.Include(x => x.BusinessPlans).FirstOrDefault(i => i.Id.Equals(userId));
            var user = context.Users.FirstOrDefault(i => i.Id.Equals(userId));
            var activity = context.Activities.FirstOrDefault(i => i.Id.Equals(activityId));
            var country = context.Countries.FirstOrDefault(i => i.Id.Equals(countryId));

            BusinessPlan plan = new BusinessPlan()
            {
                Title = title,
                Activity = activity,
                Country = country,
                User = user
            };

            context.BusinessPlans.Add(plan);
            return plan;
        }

        public void Remove(Guid userId, Guid planId)
        {            
            BusinessPlan businessPlan = context.BusinessPlans.FirstOrDefault(i => i.Id.Equals(planId));
            context.BusinessPlans.Remove(businessPlan);
            context.SaveChanges();
           // return plan;
        }

        public BusinessPlan GetSelectedPlan(Guid userId, Guid planId)
        {
            BusinessPlan businessPlan = context.BusinessPlans.FirstOrDefault(i => i.Id.Equals(planId));
            if (businessPlan != null)
            {
                return businessPlan;
            }
            else
                throw new Exception("Plan was not found");            
        }
    }
}