using KabadaAPI.DataSource.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KabadaAPI.Controllers {
  [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        private readonly IConfiguration config;

        public CountryController(IConfiguration config){ this.config = config; }

       [HttpGet]
        public IActionResult GetAll()
        {
            CountryRepository repository = new CountryRepository(config);
            return Ok(repository.GetCountries());
        }
    }
}
