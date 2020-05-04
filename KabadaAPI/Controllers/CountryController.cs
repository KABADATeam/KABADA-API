using System;
using System.Collections.Generic;
using KabadaAPI.DataSource.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace KabadaAPI.Controllers
{
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public IActionResult GetAllinfo()
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
        [HttpGet]
        [Route("latitude/{country}")]
        public IActionResult GetCountriesLatitude(string country)
        {
            CountryRepository Cntrlatitude = new CountryRepository();
            return Ok(Cntrlatitude.GetLatitude(country));
        }
        [HttpGet]
        [Route("longitude/{country}")]
        public IActionResult GetCountriesLongitude(string country)
        {
            CountryRepository Cntrlongitude = new CountryRepository();
            return Ok(Cntrlongitude.GetLongitude(country));
        }
        [HttpGet]
        [Route("contriesList")]
        public IActionResult GetCountriesList()
        {
            CountryRepository Cntrlist = new CountryRepository();
            //List<string> CountryList = new List<string>();
            return Ok(Cntrlist.GetList());
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
