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
using Microsoft.AspNetCore.Authorization;

namespace KabadaAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UserBusinessPlanController : ControllerBase
    {
        [Authorize(Roles = Role.User)]      // [Authorize(Roles = Role.Admin)]
        [HttpGet]
        [Route("{userId}/plans")]
        public IActionResult GetPlans(Guid userId)
        {
            UserPlanRepository repository = new UserPlanRepository();
            return Ok(repository.GetPlans(userId));
          
        }

        [Authorize(Roles = Role.User)]
        [HttpPost]
        [Route("{userId}/plans")]
        public IActionResult AddPlan([FromBody]BusinessPlan businessPlan, Guid userId)
        {
            UserPlanRepository repository = new UserPlanRepository();
            repository.Save(userId, businessPlan.Title, businessPlan.ActivityId, businessPlan.CountryId);
            return Ok();
        }
    }
}