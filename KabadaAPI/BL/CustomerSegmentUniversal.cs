using Kabada;
using KabadaAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class CustomerSegmentUniversal  {
    public CustomerSegmentUniversal() { minorAttributes=new Dictionary<short, List<Guid>>(); }

    public Dictionary<short, List<Guid>> minorAttributes;
    public bool? flag;
    public string v1;
    public string v2;

    public string pack(){  return Newtonsoft.Json.JsonConvert.SerializeObject(this, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); }

    internal List<Codifier> decode(TexterRepository.EnumTexterKind kind, Dictionary<Guid, Codifier> codes) {
      List<Guid> w=null;
      if(!minorAttributes.TryGetValue((short)kind, out w))
        return null;
      var r=new List<Codifier>();
      foreach(var o in w)
        r.Add(codes[o]);
      return r;
      }
    }
  }
