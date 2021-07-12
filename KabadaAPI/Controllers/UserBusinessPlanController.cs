using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Kabada;

namespace KabadaAPI.Controllers {
  [Authorize]
    [ApiController]
    [Route("api/plans")]
    public class UserBusinessPlanController : KController
    {
        public UserBusinessPlanController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) { }

        protected UsersPlansRepository pRepo { get { return new UsersPlansRepository(context); } }

        [Authorize(Roles = Role.User)]      // [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public ActionResult<PrivateBusinessPlans_ret> GetPlans(){ return Grun<PrivateBusinessPlans_ret>(_GetPlans); }
        private ActionResult<PrivateBusinessPlans_ret> _GetPlans(){
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

                return new PrivateBusinessPlans_ret() { privateBusinessPlans = privatePlans };
        }

        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult AddPlan([FromBody] BusinessPlan businessPlan){ return prun<BusinessPlan>(_AddPlan, businessPlan); }
        private IActionResult _AddPlan([FromBody] BusinessPlan businessPlan){
                 using (var repository = pRepo)
                {
                    var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                    var plan = repository.Save(userId, businessPlan.Title, businessPlan.ActivityId, businessPlan.LanguageId,businessPlan.Img,businessPlan.CountryId);
                    return Ok(plan);
                }
        }

        [Route("remove")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult RemovePlan([FromBody] BusinessPlan businessPlan){ return prun<BusinessPlan>(_RemovePlan, businessPlan); }
        private IActionResult _RemovePlan([FromBody] BusinessPlan businessPlan){
                UsersPlansRepository repository = new UsersPlansRepository(context);
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
        public ActionResult<PublicBusinessPlans_ret> GetPublicPlans(){ return Grun<PublicBusinessPlans_ret>(_GetPublicPlans);}
        private ActionResult<PublicBusinessPlans_ret> _GetPublicPlans(){
                BusinessPlansRepository repository = new BusinessPlansRepository(context);
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
                return new PublicBusinessPlans_ret() { publicBusinessPlans = publicPlans };//repository.GetPublicPlans();
        }
        [Route("changeSwotCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangeSwotCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeSwotCompleted, planUpdate); }
        private IActionResult _changeSwotCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangeSwotCompleted(planUpdate.business_plan_id, planUpdate.is_swot_completed, uGuid);
            return Ok("Success");
        }
        [Route("changeCostCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangeCostCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeSwotCompleted, planUpdate); }
        private IActionResult _changeCostCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangeCostCompleted(planUpdate.business_plan_id, planUpdate.is_cost_completed, uGuid);
            return Ok("Success");
        }
        [Route("changeResourcesCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangeResourcesCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeResourcesCompleted, planUpdate); }
        private IActionResult _changeResourcesCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangeResourcesCompleted(planUpdate.business_plan_id, planUpdate.is_resources_completed, uGuid);
            return Ok("Success");
        }
        [Route("changePartnersCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangePartnersCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changePartnersCompleted, planUpdate); }
        private IActionResult _changePartnersCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangePartnersCompleted(planUpdate.business_plan_id, planUpdate.is_partners_completed, uGuid);
            return Ok("Success");
        }
        [Route("changePropositionCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangePropositionCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changePropositionCompleted, planUpdate); }
        private IActionResult _changePropositionCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangePropositionCompleted(planUpdate.business_plan_id, planUpdate.is_proposition_completed, uGuid);
            return Ok("Success");
        }
        [Route("changeRevenueCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangeRevenueCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeRevenueCompleted, planUpdate); }
        private IActionResult _changeRevenueCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangeRevenueCompleted(planUpdate.business_plan_id, planUpdate.is_revenue_completed, uGuid);
            return Ok("Success");
        }
    }
}