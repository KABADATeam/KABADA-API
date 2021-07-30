using System;
using System.Linq;

namespace KabadaAPI {
  public class IndustryRepository : BaseRepository {
     public IndustryRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

     protected override object[] getAll4snap() { return daContext.Industries.ToArray(); }
     protected override string myTable => "Industries";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted) {
      return loadDataRow<KabadaAPIdao.Industry, Guid>(daContext.Industries, json, overwrite, oldDeleted);
      }

     //protected override bool loadData(string json, bool overwrite) {
     // var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.Industry>(json);
     // daContext.Industries.Add(o);
     // return true;
     // }
    }
  }
