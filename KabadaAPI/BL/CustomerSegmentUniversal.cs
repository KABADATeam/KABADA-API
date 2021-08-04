using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class CustomerSegmentUniversal  {
    public CustomerSegmentUniversal() { minorAttributes=new Dictionary<short, List<Guid>>(); }

    public Dictionary<short, List<Guid>> minorAttributes;
    public bool? flag;

    public string pack(){  return Newtonsoft.Json.JsonConvert.SerializeObject(this, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); }
    }
  }
