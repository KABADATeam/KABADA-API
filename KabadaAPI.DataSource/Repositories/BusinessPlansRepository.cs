using KabadaAPI.DataSource.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KabadaAPI.DataSource.Repositories
{
    public class BusinessPlansRepository : BaseRepository
    {
      public BusinessPlansRepository(Microsoft.Extensions.Configuration.IConfiguration configuration) : base(configuration) { }

        public List<BusinessPlan> GetPublicPlans()
        {
            return Getplans().Where(x => x.Public == true).OrderBy(x => x.Title).ToList();
        }
        protected IQueryable<BusinessPlan> Getplans()
        {
            var p = context.BusinessPlans.Include(x => x.Country).Include(x => x.User)
                    .Include(x => x.Activity.Industry);
            return p;
        }
    }
}