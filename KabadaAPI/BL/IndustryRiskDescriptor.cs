using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class IndustryRiskDescriptor {
    public string fileName;
    public DateTime loadStartedUtc;
    public List<IndustryRiskElementBL> risks;

    public IndustryRiskDescriptor() {}

    internal string pack() {
      return JsonConvert.SerializeObject(this, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); 
      }
    }
  }
