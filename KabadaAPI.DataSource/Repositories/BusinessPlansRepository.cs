using KabadaAPI.DataSource.Models;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI.DataSource.Repositories
{
    public class BusinessPlansRepository : BaseRepository
    {

        public List<BusinessPlan> GetPublicPlans()
        {
            return context.BusinessPlans.Where(x => x.Public == true)
                   .OrderBy(x => x.Title)
                   .ToList();
        }
        
    }
}