using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public class Plan_AttributeRepository : BaseRepository {
    public enum PlanAttributeKind { swot=1, keyResource=2 }

    public Plan_AttributeRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    protected List<Plan_Attribute> get(Guid plan, PlanAttributeKind such){
      var w=(short)such;
      var r=daContext.Plan_Attributes.Where(x=>x.BusinessPlanId==plan && x.Kind==w).ToList();
      return r;
      }

    public List<Plan_Attribute> getSwots(Guid plan){ return get(plan, PlanAttributeKind.swot); }
    public List<Plan_Attribute> getResources(Guid plan){ return get(plan, PlanAttributeKind.keyResource); }

    public void Delete(Plan_Attribute me) {
      daContext.Plan_Attributes.Remove(me);
      daContext.SaveChanges();
      }

    public void Save(Plan_Attribute olduks) {
      daContext.SaveChanges();
      }

    public Plan_Attribute Create(Plan_Attribute me) {
      daContext.Plan_Attributes.Add(me);
      daContext.SaveChanges();
      return me;
      }
    }
  }
