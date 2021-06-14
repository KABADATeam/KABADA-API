using KabadaAPI.BL;
using System.Collections.Generic;

namespace KabadaAPI.ViewModels {
  partial class ResourceSelection {

    internal void fill(Tertex tvo) {
      this.title=tvo.me.Value;
      this.options=Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResourceOption>>(tvo.me.LongValue);
      }
     }
  }
