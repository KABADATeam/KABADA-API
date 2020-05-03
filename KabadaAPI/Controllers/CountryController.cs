using System;
using System.Collections.Generic;
using KabadaAPI.DataSource.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KabadaAPI.Controllers
{
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public IActionResult GetAllCountries()
        {
            CountryRepository CntrName = new CountryRepository();
            return Ok(CntrName.GetCountries());
        }

        [HttpGet]
        [Route("language/{country}")]
        public IActionResult GetCountriesLanguage( string country)//pasitikrinti
        {
            CountryRepository CntrName = new CountryRepository();
            return Ok(CntrName.GetLanguage(country));
        }

        [HttpPost]
        [Route("entry")]
        public IActionResult PostCountry()
        {
            CountryRepository repository = new CountryRepository();
            List<string> CountryList = repository.CountryNameList();
            return Ok(CountryList);
        }
    }
}
