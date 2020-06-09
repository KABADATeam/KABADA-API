using System;
using System.Collections.Generic;
using KabadaAPI.DataSource.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KabadaAPI.ViewModels;
namespace KabadaAPI.Controllers
{
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            CountryRepository repository = new CountryRepository();
            return Ok(repository.GetCountries());
        }
    }
}
