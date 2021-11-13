using System.Collections.Generic;
using KabadaAPIdao;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace KabadaAPI {
  public class CountryRepository : BaseRepository  {
    public CountryRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    protected DbSet<Country> q0 { get { return daContext.Countries; }}
   
    public IQueryable<Country> Q(string shortName=null, Guid? id=null, bool? orderByTitle=false){
      var r=q0.AsQueryable();
      if(shortName!=null)
        r=r.Where(x=>x.ShortCode==shortName);
      if(orderByTitle==true)
        r=r.OrderBy(x=>x.Title);
      return r;
      }

    public List<Country> GetCountries() { return Q(orderByTitle: true).ToList(); }

    protected override object[] getAll4snap() { return q0.ToArray(); }
    protected override string myTable => "Countries";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.Country, Guid>(daContext.Countries, json, overwrite, oldDeleted, generateInits);
      }

    protected override Guid? guid(string json) {
      var o = Newtonsoft.Json.JsonConvert.DeserializeObject<Country>(json);
      return o.Id;
      }

    }
}
