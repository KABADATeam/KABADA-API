using KabadaAPI.DataSource.Models;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI.DataSource.Repositories
{
    public class BusinessPlansRepository : BaseRepository
    {
      public BusinessPlansRepository(Microsoft.Extensions.Configuration.IConfiguration configuration) : base(configuration) { }

        public List<BusinessPlan> GetPublicPlans()
        {
            return context.BusinessPlans.Where(x => x.Public == true)
                   .OrderBy(x => x.Title)
                   .ToList();
        }
        
    }
}