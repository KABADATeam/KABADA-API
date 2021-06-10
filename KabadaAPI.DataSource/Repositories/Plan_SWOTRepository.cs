//using KabadaAPI.DataSource.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace KabadaAPI.DataSource.Repositories {
//  public class Plan_SWOTRepository : BaseRepository {
//    public Plan_SWOTRepository(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger =null, Context context=null)
//      : base(configuration, logger, context) { }

//    public List<Plan_SWOT> get(Guid plan){
//      var r=context.Plan_SWOTs.Where(x=>x.BusinessPlanId==plan).ToList();
//      return r;
//      }

//    public void Delete(Plan_SWOT me) {
//      context.Plan_SWOTs.Remove(me);
//      context.SaveChanges();
//      }

//    public void Save(Plan_SWOT olduks) {
//      context.SaveChanges();
//      }

//    public Plan_SWOT Create(Plan_SWOT me) {
//      context.Plan_SWOTs.Add(me);
//      context.SaveChanges();
//      return me;
//      }
//    }
//  }
