using System;
using Microsoft.AspNetCore.Mvc;
using KabadaAPI.ViewModels;
using KabadaAPI.DataSource.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections.Generic;

namespace KabadaAPI.Controllers {
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

        protected UsersPlansRepository pRepo { get { return new UsersPlansRepository(config); }}

        [Authorize(Roles = Role.User)]      // [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetPlans()
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                var repository = pRepo;
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
                using (var repository = pRepo)
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

        [Route("remove")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult RemovePlan([FromBody]BusinessPlan businessPlan)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                UsersPlansRepository repository = new UsersPlansRepository(config);
                repository.Remove(userId, businessPlan.Id);
                return Ok("Success");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [Route("fetch")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult GetSelectedPlan([FromBody]BusinessPlan businessPlan)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                var repository = pRepo;
                var plan = repository.GetSelectedPlan(userId, businessPlan.Id);
                return Ok(plan);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [AllowAnonymous]
        [Route("public")]
        [HttpGet]
        public IActionResult GetPublicPlans()
        {
            try
            {
                BusinessPlansRepository repository = new BusinessPlansRepository(config);
                var plans = repository.GetPublicPlans();
                var publicPlans = new PublicBusinessPlans() { BusinessPlan = new List<PublicBusinessPlan>() };
                foreach (var p in plans)
                {
                    publicPlans.BusinessPlan.Add(new PublicBusinessPlan
                    {
                        Id = p.Id,
                        name = p.Title,
                        industry = p.Activity?.Industry.Title,
                        country = p.Country?.Title,
                        dateCreated = p.Created.Date,
                        owner = String.Format("{0} {1}", p.User.Name, p.User.Surname),
                        ownerAvatar = p.User.UserPhoto
                    }) ;
                }
                return Ok(new PublicBusinessPlans_ret() { publicBusinessPlans = publicPlans });//repository.GetPublicPlans());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }

        }

    }
}