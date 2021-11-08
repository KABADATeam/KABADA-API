using Kabada;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class IndustryRiskDescriptor {
    public string fileName;
    public DateTime loadStartedUtc;
    public List<IndustryRisk> risks;

    public IndustryRiskDescriptor() {}

    internal string pack() {
      return JsonConvert.SerializeObject(this, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); 
      }

    public static IndustryRiskDescriptor ById(Guid id, BLontext blContext, DAcontext daContext=null){
      var z=new TexterRepository(blContext, daContext).getById(id);
      var r=JsonConvert.DeserializeObject<IndustryRiskDescriptor>(z.LongValue);
      return r;
      }

    public static IndustryRiskDescriptor ByActivityId(Guid id, BLontext blContext, DAcontext daContext=null){
      var w=new IndustryActivityRepository(blContext, daContext).getMyRisks(id);
      if(w==null)
        return null;
      var z=new TexterRepository(blContext, daContext).getById(w.Value);
      var r=JsonConvert.DeserializeObject<IndustryRiskDescriptor>(z.LongValue);
      return r;
      }

    public static IndustryRiskDescriptor ByActivityName(string name, BLontext blContext, DAcontext daContext=null){
      var w=new IndustryActivityRepository(blContext, daContext).byCode(name);
      return ByActivityId(w.Id, blContext, daContext);
      }
    }
  }
