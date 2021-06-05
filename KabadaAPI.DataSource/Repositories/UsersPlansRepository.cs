using KabadaAPI.DataSource.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI.DataSource.Repositories {
  public class UsersPlansRepository : BaseRepository
    {
      public UsersPlansRepository(Microsoft.Extensions.Configuration.IConfiguration configuration) : base(configuration) { }

        public List<BusinessPlan> GetPlans(Guid userId)
        {
            //User user = context.Users.Include(x => x.BusinessPlans).FirstOrDefault(i => i.Id.Equals(userId));
            var plans = context.BusinessPlans.Where(x => x.User.Id.Equals(userId));
            if (plans != null)
            {
                return plans.ToList();
            }
            else
                throw new Exception("No plans found");
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
                Country = country
            };

         //   user.BusinessPlans.Add(plan);
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