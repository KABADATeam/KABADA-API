using KabadaAPI.DataSource.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace KabadaAPI.DataSource.Repositories
{
    public class BusinessPlansRepository : BaseRepository
    {
        public BusinessPlansRepository(Microsoft.Extensions.Configuration.IConfiguration configuration) : base(configuration) { }

        public List<BusinessPlan> GetPublicPlans()
        {
            var plans = context.BusinessPlans.Where(x => x.Public == true).Include(x => x.Country).Include(x => x.User)
                    .Include(x => x.Activity.Industry);
            if (plans != null)
            {
                return plans.OrderBy(x => x.Title).ToList();
            }
            else
                throw new Exception("No plans found");
        }
    }
}