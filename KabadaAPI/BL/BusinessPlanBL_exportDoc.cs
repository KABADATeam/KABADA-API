using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  partial class BusinessPlanBL {
    public string naceCode { get { return (o.Activity==null)?null:$"{o.Activity.Code} - {o.Activity.Title}"; }}

    public List<string> keyRes { get { return myKeyResource_s.Select(x=>x.e.name).ToList(); }}

    public List<string> keyDist { get { return rvpL(PlanAttributeKind.keyDistributor); }}
    
    public List<string> keySupp { get { return rvpL(PlanAttributeKind.keySupplier); }}
    }
  }
