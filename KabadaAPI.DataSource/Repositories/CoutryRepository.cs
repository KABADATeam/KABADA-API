using System.Collections.Generic;
using KabadaAPI.DataSource.Models;
using System.Linq;

namespace KabadaAPI.DataSource.Repositories {
  public class CountryRepository : BaseRepository
    {
       public CountryRepository(Microsoft.Extensions.Configuration.IConfiguration configuration) : base(configuration) { }

       public List<Country> GetCountries()
        {
            var list = context.Countries.ToList();
            return list.OrderBy(x => x.Title).ToList();
        }
    }
}
