using KabadaAPIdao;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace KabadaAPI.DataSource.Repositories
{
    public class BusinessPlansRepository : BaseRepository
    {
        public BusinessPlansRepository(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger =null) : base(configuration, logger) { }

        public List<BusinessPlan> GetPublicPlans()
        {
            var plans = context.BusinessPlans.Where(x => x.Public == true)
                        .Include(x => x.Country).Include(x => x.User)
                        .Include(x => x.Activity.Industry);
            return plans.OrderBy(x => x.Title).ToList();           
        }
        public void ChangeSwotCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId,planId);
            businessPlan.IsSwotCompleted = newValue;
            context.SaveChanges();
        }
        public void ChangeResourcesCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsResourcesCompleted = newValue;
            context.SaveChanges();
        }
        public BusinessPlan GetPlan(Guid planId)
        {
           return context.BusinessPlans.FirstOrDefault(i => i.Id.Equals(planId));            
        }
        public BusinessPlan GetPlanForUpdate(Guid userId, Guid planId)
        {
            var mp = context.BusinessPlans.Include(x =>x.User).FirstOrDefault(i => i.Id.Equals(planId) && i.User.Id.Equals(userId));            
            if (mp!=null) return mp; 
            var shp = context.SharedPlans.Where(i => i.BusinessPlanId.Equals(planId) && i.UserId.Equals(userId)).Include(x =>x.BusinessPlan).FirstOrDefault();
            if (shp?.BusinessPlan != null) return shp.BusinessPlan;
            throw new Exception("No plan found for update");
        }
    }
}