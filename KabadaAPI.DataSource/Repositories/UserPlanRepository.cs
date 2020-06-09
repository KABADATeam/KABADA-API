using KabadaAPI.DataSource.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KabadaAPI.DataSource.Repositories
{
    public class UserPlanRepository
    {

        protected Context context;

        public UserPlanRepository()
        {
            context = new Context();
        }

        public List<BusinessPlan> GetPlans(Guid userId)
        {
            User user = context.Users.FirstOrDefault(i => i.Id.Equals(userId));

            if (user?.BusinessPlans != null)
            {
                return user.BusinessPlans;
            }
            else
                throw new Exception("Plan was not found");
        }

        public void Save(Guid userId, string title, Guid activityId, Guid countryId)
        {
            User user = context.Users.FirstOrDefault(i => i.Id.Equals(userId));
            var activity = context.Activities.FirstOrDefault(i => i.Id.Equals(activityId));
            var country = context.Countries.FirstOrDefault(i => i.Id.Equals(countryId));

            user.BusinessPlans.Add(new BusinessPlan()
            {
                Title = title,
                Activity = activity,
                Country = country
            });
            context.SaveChanges();
        }
    }
}