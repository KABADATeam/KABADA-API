using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KabadaAPI.ViewModels;
using KabadaAPI.DataSource.Repositories;
using Microsoft.Extensions.Logging;
using KabadaAPI.Utilities;
using Microsoft.Extensions.Configuration;


namespace KabadaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBusinessPlanController : ControllerBase
    {
      /*  [HttpGet]
        [Route("all")]
        public IActionResult GetSelections()
        {
            SelectionRepository repository = new SelectionRepository();
            return Ok(repository.GetSelections());
        }
        */
        [HttpPost]
        [Route("/{title}/{activityId}/{CountryId}/{userId}")]
        public IActionResult AddInformation(string title, Guid activityId, Guid CountryId, Guid userId)
        {
            UserPlanRepository repository = new UserPlanRepository();
            repository.AddInfo(title, activityId,CountryId, userId);
            return Ok(repository.AddInfo(title, activityId, CountryId, userId));
        }
    }
    }
