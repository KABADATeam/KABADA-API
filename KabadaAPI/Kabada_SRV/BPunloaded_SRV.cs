using Newtonsoft.Json;

namespace Kabada {
  partial class BPunloaded {
    public string pack() {
      var r=JsonConvert.SerializeObject(this, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
      return r;
    }
  }
}
