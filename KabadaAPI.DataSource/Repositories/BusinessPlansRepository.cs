using KabadaAPI.DataSource.Models;
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
        public void ChangeSwotCompleted(Guid planId, bool newValue)
        {
            BusinessPlan businessPlan = context.BusinessPlans.FirstOrDefault(i => i.Id.Equals(planId));
            businessPlan.IsSwotCompleted = newValue;
            context.SaveChanges();
        }
        public BusinessPlan GetPlan(Guid planId)
        {
           return context.BusinessPlans.FirstOrDefault(i => i.Id.Equals(planId));            
        }

    }
}