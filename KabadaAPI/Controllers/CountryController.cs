using KabadaAPI.DataSource.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KabadaAPI.Controllers {
  [Route("api/countries")]
    public class CountryController : KController
    {

        public CountryController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

       [HttpGet]
        public IActionResult GetAll() { return grun(_GetAll); }
        private IActionResult _GetAll() {
            CountryRepository repository = new CountryRepository(config, _logger);
            return Ok(repository.GetCountries());
        }
    }
}
