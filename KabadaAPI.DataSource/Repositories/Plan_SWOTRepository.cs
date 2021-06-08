using KabadaAPI.DataSource.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI.DataSource.Repositories {
  public class Plan_SWOTRepository : BaseRepository {
    public Plan_SWOTRepository(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger =null) : base(configuration, logger) { }

    public List<Plan_SWOT> get(Guid plan){
      var r=context.Plan_SWOTs.Where(x=>x.BusinessPlanId==plan).ToList();
      return r;
      }
   }
  }
