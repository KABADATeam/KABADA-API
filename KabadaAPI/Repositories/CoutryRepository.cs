using System.Collections.Generic;
using KabadaAPIdao;
using System.Linq;
using System;

namespace KabadaAPI {
  public class CountryRepository : BaseRepository
    {
       public CountryRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

       public List<Country> GetCountries()
        {
            var list = daContext.Countries.ToList();
            return list.OrderBy(x => x.Title).ToList();
        }
    protected override object[] getAll4snap() { return daContext.Countries.ToArray(); }
    protected override string myTable => "Countries";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.Country, Guid>(daContext.Countries, json, overwrite, oldDeleted, generateInits);
      }

    //protected override bool loadData(string json, bool overwrite) {
    //  var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.Country>(json);
    //  daContext.Countries.Add(o);
    //  return true;
    //  }
    }
}
