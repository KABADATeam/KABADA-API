using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  internal class LanguagesRepository : BaseRepository {
    public LanguagesRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    public List<Language> get() {
      var r = daContext.Languages.OrderBy(x=>x.Code).ToList();
      return r;
      }
    protected override object[] getAll4snap() { return daContext.Languages.ToArray(); }
    protected override string myTable => "Languages";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted) {
      return loadDataRow<KabadaAPIdao.Language, Guid>(daContext.Languages, json, overwrite, oldDeleted);
      }

    //protected override bool loadData(string json, bool overwrite) {
    //  var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.Language>(json);
    //  daContext.Languages.Add(o);
    //  return true;
    //  }
    }
  }
