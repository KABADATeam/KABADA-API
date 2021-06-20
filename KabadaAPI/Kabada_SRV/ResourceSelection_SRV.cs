using KabadaAPI;
using System.Collections.Generic;

namespace Kabada {
  partial class ResourceSelection {

    internal void fill(Tertex tvo) {
      this.title=tvo.me.Value;
      var dao=tvo.me.LongValue;
      if(!string.IsNullOrWhiteSpace(dao))
        this.options=Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResourceOption>>(dao);
      }
     }
  }
