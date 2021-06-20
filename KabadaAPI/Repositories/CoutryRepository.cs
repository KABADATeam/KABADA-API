using System.Collections.Generic;
using KabadaAPIdao;
using System.Linq;

namespace KabadaAPI {
  public class CountryRepository : BaseRepository
    {
       public CountryRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

       public List<Country> GetCountries()
        {
            var list = daContext.Countries.ToList();
            return list.OrderBy(x => x.Title).ToList();
        }
    }
}
