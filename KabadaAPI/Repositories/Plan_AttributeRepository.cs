using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public class Plan_AttributeRepository : BaseRepository {
    public enum PlanAttributeKind { swot=1, keyResource=2 }

    public Plan_AttributeRepository(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger =null, DAcontext context =null)
      : base(configuration, logger, context) { }

    public List<Plan_Attribute> get(Guid plan, PlanAttributeKind such){
      var w=(short)such;
      var r=context.Plan_Attributes.Where(x=>x.BusinessPlanId==plan && x.Kind==w).ToList();
      return r;
      }

    public void Delete(Plan_Attribute me) {
      context.Plan_Attributes.Remove(me);
      context.SaveChanges();
      }

    public void Save(Plan_Attribute olduks) {
      context.SaveChanges();
      }

    public Plan_Attribute Create(Plan_Attribute me) {
      context.Plan_Attributes.Add(me);
      context.SaveChanges();
      return me;
      }
    }
  }
