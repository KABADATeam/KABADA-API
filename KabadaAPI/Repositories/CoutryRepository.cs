using System.Collections.Generic;
using KabadaAPIdao;
using System.Linq;

namespace KabadaAPI {
  public class CountryRepository : BaseRepository
    {
       public CountryRepository(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger =null) : base(configuration, logger) { }

       public List<Country> GetCountries()
        {
            var list = context.Countries.ToList();
            return list.OrderBy(x => x.Title).ToList();
        }
    }
}
