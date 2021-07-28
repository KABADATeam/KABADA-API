using KabadaAPIdao;
using System;
using System.Linq;

namespace KabadaAPI {
  public class SharedPlanRepository: BaseRepository {
    public SharedPlanRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    internal void add(SharedPlan sharedPlan) {
      if(daContext.SharedPlans.Where(x=>x.BusinessPlanId==sharedPlan.BusinessPlanId && x.UserId==sharedPlan.UserId).Count()>0)
        throw new Exception("duplicates not allowed");
      daContext.SharedPlans.Add(sharedPlan);
      daContext.SaveChanges();
      }

     protected override object[] getAll4snap() { return daContext.SharedPlans.ToArray(); }

    protected override string myTable => "SharedPlans";

    protected override void loadData(string json) {
      var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.SharedPlan>(json);
      daContext.SharedPlans.Add(o);
      }
    }
  }
