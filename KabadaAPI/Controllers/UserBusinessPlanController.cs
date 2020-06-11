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
using System.Security.Claims;

namespace KabadaAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/plans")]
    public class UserBusinessPlanController : ControllerBase
    {
        private readonly IConfiguration config;

        public UserBusinessPlanController(IConfiguration config)
        {
            this.config = config;
        }

        [Authorize(Roles = Role.User)]      // [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetPlans()
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                UsersPlansRepository repository = new UsersPlansRepository();
                return Ok(repository.GetPlans(userId));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
          
        }

        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult AddPlan([FromBody]BusinessPlan businessPlan)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");

            try
            {               
                using (UsersPlansRepository repository = new UsersPlansRepository())
                {
                    var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                    var plan = repository.Save(userId, businessPlan.Title, businessPlan.ActivityId, businessPlan.CountryId);
                    return Ok(plan);
                }
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}