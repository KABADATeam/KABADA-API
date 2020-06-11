using KabadaAPI.DataSource.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KabadaAPI.DataSource.Repositories
{
    public class UsersPlansRepository : BaseRepository
    {

        public List<BusinessPlan> GetPlans(Guid userId)
        {
            User user = context.Users.Include(x => x.BusinessPlans).FirstOrDefault(i => i.Id.Equals(userId));

            if (user?.BusinessPlans != null)
            {
                return user.BusinessPlans;
            }
            else
                throw new Exception("Plan was not found");
        }

        public BusinessPlan Save(Guid userId, string title, Guid activityId, Guid countryId)
        {
            User user = context.Users.Include(x => x.BusinessPlans).FirstOrDefault(i => i.Id.Equals(userId));
            var activity = context.Activities.FirstOrDefault(i => i.Id.Equals(activityId));
            var country = context.Countries.FirstOrDefault(i => i.Id.Equals(countryId));

            BusinessPlan plan = new BusinessPlan()
            {
                Title = title,
                Activity = activity,
                Country = country
            };

            user.BusinessPlans.Add(plan);
            return plan;
        }
    }
}