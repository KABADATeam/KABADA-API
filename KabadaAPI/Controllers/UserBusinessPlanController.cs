using System;
using Microsoft.AspNetCore.Mvc;
using KabadaAPI;
using KabadaAPI.DataSource.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace KabadaAPI.Controllers {
  [Authorize]
    [ApiController]
    [Route("api/plans")]
    public class UserBusinessPlanController : KController
    {
        public UserBusinessPlanController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) { }

        protected UsersPlansRepository pRepo { get { return new UsersPlansRepository(config, _logger); } }

        [Authorize(Roles = Role.User)]      // [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetPlans(){ return grun(_GetPlans); }
        private IActionResult _GetPlans(){
                var userId = uGuid;
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

        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult AddPlan([FromBody] BusinessPlan businessPlan){ return prun<BusinessPlan>(_AddPlan, businessPlan); }
        private IActionResult _AddPlan([FromBody] BusinessPlan businessPlan){
                 using (var repository = pRepo)
                {
                    var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                    var plan = repository.Save(userId, businessPlan.Title, businessPlan.ActivityId, businessPlan.CountryId);
                    return Ok(plan);
                }
        }

        [Route("remove")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult RemovePlan([FromBody] BusinessPlan businessPlan){ return prun<BusinessPlan>(_RemovePlan, businessPlan); }
        private IActionResult _RemovePlan([FromBody] BusinessPlan businessPlan){
                UsersPlansRepository repository = new UsersPlansRepository(config, _logger);
                repository.Remove(uGuid, businessPlan.Id);
                return Ok("Success");
        }

        [Route("fetch")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult GetSelectedPlan([FromBody] BusinessPlan businessPlan){ return prun<BusinessPlan>(_GetSelectedPlan, businessPlan); }
        private IActionResult _GetSelectedPlan([FromBody] BusinessPlan businessPlan){
                var plan = pRepo.GetSelectedPlan(uGuid, businessPlan.Id);
                return Ok(plan);
        }

        [AllowAnonymous]
        [Route("public")]
        [HttpGet]
        public IActionResult GetPublicPlans(){ return grun(_GetPublicPlans);}
        private IActionResult _GetPublicPlans(){
                BusinessPlansRepository repository = new BusinessPlansRepository(config, _logger);
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
        [Route("changeSwotCompleted")]
        [Authorize]
        [HttpPost]
        public IActionResult ChangeSwotCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeSwotCompleted, planUpdate); }
        private IActionResult _changeSwotCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(config, _logger);
            repo.ChangeSwotCompleted(planUpdate.business_plan_id, planUpdate.is_swot_completed, uGuid);
            return Ok("Success");
        }
        //[Route("changeResourcesCompleted")]
        //[Authorize]
        //[HttpPost]
        //public IActionResult ChangeResourcesCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeResourcesCompleted, planUpdate); }
        private IActionResult _changeResourcesCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(config, _logger);
            repo.ChangeResourcesCompleted(planUpdate.business_plan_id, planUpdate.is_resources_completed, uGuid);
            return Ok("Success");
        }

    }
}