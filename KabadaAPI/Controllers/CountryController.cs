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
        public IActionResult GetAllinfo()//if need to see all table info
        {
            CountryRepository CntrName = new CountryRepository();
            return Ok(CntrName.GetCountries());
        }

        [HttpGet]
        [Route("languages/{country}/{language}")]//???????????????????????????
        public IActionResult GetCountriesLanguage( string country, string language)//if need one country language
        {
            CountryRepository CntrName = new CountryRepository();
            return Ok(CntrName.GetLanguage(country,language));
        }
        [HttpGet]
        [Route("latitude/{country}")]// if need one country latitude
        public IActionResult GetCountriesLatitude(string country)
        {
            CountryRepository Cntrlatitude = new CountryRepository();
            return Ok(Cntrlatitude.GetLatitude(country));
        }
        [HttpGet]
        [Route("longitude/{country}")]//if need one country longitude
        public IActionResult GetCountriesLongitude(string country)
        {
            CountryRepository Cntrlongitude = new CountryRepository();
            return Ok(Cntrlongitude.GetLongitude(country));
        }
        [HttpGet]
        [Route("contriesList/{language}")]//if need list of countyNames;
        public IActionResult GetCountriesList(string language)
        {
            CountryRepository Cntrlist = new CountryRepository();
            //List<string> CountryList = new List<string>();
            return Ok(Cntrlist.GetList(language));
        }

        [HttpPost]
        [Route("entry")]//if need to fill database
        public IActionResult PostCountry()
        {
            CountryRepository repository = new CountryRepository();
            List<string> CountryList = repository.CountryNameList();
            return Ok(CountryList);
        }
    }
}
