using System;
using Microsoft.AspNetCore.Mvc;
using KabadaAPI.ViewModels;
using KabadaAPI.DataSource.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace KabadaAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/plans")]
    public class UserBusinessPlanController : KController
    {
        public UserBusinessPlanController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) { }

        protected UsersPlansRepository pRepo { get { return new UsersPlansRepository(config); } }

        [Authorize(Roles = Role.User)]      // [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetPlans()
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                var repository = pRepo;
                _logger.LogInformation($"-- List of plans for user={userId}");
                var plans = repository.GetPlans(userId);
                var privatePlans = new PrivateBusinessPlans();
                foreach (var p in plans)
                {
                    privatePlans.BusinessPlan.Add(new PrivateBusinessPlan
                    {
                        Id = p.Id,
                        name = p.Title,
                        dateCreated = p.Created.Date,
                        Public = p.Public,
                        planImage = p.Img,                      
                        SharedWithMe = p.User.Id!=userId?true:false
                    }) ;
                }
                _logger.LogInformation($"-- List of plans for user={userId}: count={privatePlans.BusinessPlan.Count}");

                return Ok(new PrivateBusinessPlans_ret() { privateBusinessPlans = privatePlans });
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }

        }

        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult AddPlan([FromBody] BusinessPlan businessPlan)
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
        public IActionResult RemovePlan([FromBody] BusinessPlan businessPlan)
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
        public IActionResult GetSelectedPlan([FromBody] BusinessPlan businessPlan)
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
                var publicPlans = new PublicBusinessPlans();
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
                    }); 
                }
                return Ok(new PublicBusinessPlans_ret() { publicBusinessPlans = publicPlans });//repository.GetPublicPlans());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }

        }
        //[Route("private")]
        //[HttpGet]
        //public IActionResult GetPrivatePlans()
        //{
        //    try
        //    {
        //        var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
        //        BusinessPlansRepository repository = new BusinessPlansRepository(config);
        //        var plans = repository.GetPlans(userId);
        //        var privatePlans = new PrivateBusinessPlans();
        //        foreach (var p in plans)
        //        {
        //            privatePlans.BusinessPlan.Add(new PrivateBusinessPlan
        //            {
        //                Id = p.Id,
        //                name = p.Title,
        //                dateCreated = p.Created.Date,
        //            });
        //        }
        //        return Ok(new PrivateBusinessPlans_ret() { privateBusinessPlans = privatePlans });//repository.GetPublicPlans());
        //    }
        //    catch (Exception exc)
        //    {
        //        return BadRequest(exc.Message);
        //    }

        //}

    }
}