﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Kabada;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KabadaAPI.Controllers {
  [Authorize]
    [ApiController]
    [Route("api/plans")]
    public class UserBusinessPlanController : KController
    {
        public UserBusinessPlanController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) { }

    //    protected UsersPlansRepository pRepo { get { return new UsersPlansRepository(context); } }
        protected BusinessPlansRepository bRepo { get { return new BusinessPlansRepository(context); } }

        [Authorize(Roles = Role.User)]      // [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public ActionResult<PrivateBusinessPlans_ret> GetPlans(){ return Grun<PrivateBusinessPlans_ret>(_GetPlans); }
        private ActionResult<PrivateBusinessPlans_ret> _GetPlans(){
                var userId = uGuid;
                var repository = bRepo;
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
                        SharedWithMe = p.UserId!=userId?true:false
                    }) ;
                }
                _logger.LogInformation($"-- List of plans for user={userId}: count={privatePlans.BusinessPlan.Count}");

                return new PrivateBusinessPlans_ret() { privateBusinessPlans = privatePlans };
        }

        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult AddPlan([FromBody] BusinessPlan businessPlan){ return prun<BusinessPlan>(_AddPlan, businessPlan); }
        private IActionResult _AddPlan([FromBody] BusinessPlan businessPlan){
                 using (var repository = bRepo)
                {
                    //var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                    if(businessPlan.ActivityId==null)
                      throw new Exception("missing Activity");
                    var plan = repository.Save(context.userGuid, businessPlan.Title, businessPlan.ActivityId.Value, businessPlan.LanguageId,businessPlan.Img,businessPlan.CountryId);
                    return Ok(plan);
                }
        }

        [Route("remove")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult RemovePlan([FromBody] BusinessPlan businessPlan){ return prun<BusinessPlan>(_RemovePlan, businessPlan); }
        private IActionResult _RemovePlan([FromBody] BusinessPlan businessPlan){
                bRepo.Remove(uGuid, businessPlan.Id);
                return Ok("Success");
        }

        [Route("fetch")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult GetSelectedPlan([FromBody] BusinessPlan businessPlan){ return prun<BusinessPlan>(_GetSelectedPlan, businessPlan); }
        private IActionResult _GetSelectedPlan([FromBody] BusinessPlan businessPlan){
                var plan = bRepo.getROe(businessPlan.Id); //.GetPlan(businessPlan.Id, uGuid);
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
                foreach (var pj in plans) {
                  var p=pj.bp;
                    publicPlans.BusinessPlan.Add(new PublicBusinessPlan
                    {
                        Id = p.Id,
                        name = p.Title,
                        industry = pj.ind?.Title,
                        country = pj.cn?.Title,
                        dateCreated = p.Created.Date,
                        owner = String.Format("{0} {1}", pj.us?.Name, pj.us?.Surname),
                        ownerAvatar = pj.us?.UserPhoto
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
        public IActionResult ChangeCostCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeCostCompleted, planUpdate); }
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
        [Route("changeChannelsCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangeChannelsCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeChannelsCompleted, planUpdate); }
        private IActionResult _changeChannelsCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangeChannelsCompleted(planUpdate.business_plan_id, planUpdate.is_channels_completed, uGuid);
            return Ok("Success");
        }

        [Route("changeStatus")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangeStatus([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeStatus, planUpdate); }
        private IActionResult _changeStatus([FromBody] ChangePlanParameter planUpdate){
            bRepo.changeStatus(planUpdate.business_plan_id, planUpdate.is_private, uGuid);
            return Ok("Success");
        }

        [Route("inviteMember")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult InviteMember([FromBody] MemberInvitation invitation) { return prun<MemberInvitation>(_inviteMember, invitation); }
        private IActionResult _inviteMember(MemberInvitation invitation){
            var r = bRepo.inviteMember(invitation.business_plan_id, invitation.email, uGuid);
            return Ok(r);
        }
        [Route("changeCustomerSegmentsCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangeCustomerSegmentsCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeCustomerSegmentsCompleted, planUpdate); }
        private IActionResult _changeCustomerSegmentsCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangeCustomerSegmentsCompleted(planUpdate.business_plan_id, planUpdate.is_customer_segments_completed, uGuid);
            return Ok("Success");
        }

        [Route("changeRelationshipCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangeRelationshipCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeRelationshipCompleted, planUpdate); }
        private IActionResult _changeRelationshipCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangeRelationshipCompleted(planUpdate.business_plan_id, planUpdate.is_customer_relationship_completed, uGuid);
            return Ok("Success");
        }

    [HttpGet]
    [Authorize]
    [Route("members/{BusinessPlan}")]
    public ActionResult<PlanMembers> MyMembers(Guid BusinessPlan) { return Prun<Guid, PlanMembers>(_MyMembers, BusinessPlan); }
    private ActionResult<PlanMembers> _MyMembers(Guid planId) {
      var r = new PlanMembers();
      r.read(context, planId, uGuid);
      return r;
      }

    [HttpDelete]
    [Authorize]
    [Route("{BusinessPlan}/member/{user_id}")]
    public IActionResult Dmember(Guid BusinessPlan, Guid user_id) { return prun<Deleter>(_Dmember, new Deleter(){ master=BusinessPlan, part=user_id}); }
    private IActionResult _Dmember(Deleter resource) {
      new SharedPlanRepository(context).deleteMember(resource, uGuid);
      return Ok("deleted");
      }

    [HttpGet]
    [Authorize]
    [Route("overview/{BusinessPlan}")]
    public ActionResult<PlanOverview> MyOverview(Guid BusinessPlan) { return Prun<Guid, PlanOverview>(_MyOverview, BusinessPlan); }
    private ActionResult<PlanOverview> _MyOverview(Guid planId) {
       var r = new PlanOverview();
      r.read(context, planId, uGuid);
      return r;
      }

    [Route("changeActivitiesCompleted")]
    [Authorize(Roles = Role.User)]
    [HttpPost]
    public IActionResult ChangeActivitiesCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeActivitiesCompleted, planUpdate); }
    private IActionResult _changeActivitiesCompleted([FromBody] ChangePlanParameter planUpdate) {
       BusinessPlansRepository repo = new BusinessPlansRepository(context);
       repo.ChangeActivitiesCompleted(planUpdate.business_plan_id, planUpdate.is_activities_completed, uGuid);
       return Ok("Success");
       }
     [Route("changeBusinessInvestmentsCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangeBusinessInvestmentsCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeBusinessInvestmentsCompleted, planUpdate); }
        private IActionResult _changeBusinessInvestmentsCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangeBusinessInvestmentsCompleted(planUpdate.business_plan_id, planUpdate.is_business_investments_completed, uGuid);
            return Ok("Success");
        }
        [Route("changeFixedVariableCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangeFixedVariableCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeFixedVariableCompleted, planUpdate); }
        private IActionResult _changeFixedVariableCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangeFixedVariableCompleted(planUpdate.business_plan_id, planUpdate.is_fixed_variable_completed, uGuid);
            return Ok("Success");
        }
        [Route("changeSalesForecastCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult ChangeSalesForecastCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeSalesForecastCompleted, planUpdate); }
        private IActionResult _changeSalesForecastCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangeSalesForecastCompleted(planUpdate.business_plan_id, planUpdate.is_sales_forecast_completed, uGuid);
            return Ok("Success");
        }
        [Route("changeAssetsCompleted")]
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public IActionResult changeAssetsCompleted([FromBody] ChangePlanParameter planUpdate) { return prun<ChangePlanParameter>(_changeAssetsCompleted, planUpdate); }
        private IActionResult _changeAssetsCompleted([FromBody] ChangePlanParameter planUpdate)
        {
            BusinessPlansRepository repo = new BusinessPlansRepository(context);
            repo.ChangeAssetsCompleted(planUpdate.business_plan_id, planUpdate.is_assets_completed, uGuid);
            return Ok("Success");
        }
        [Route("update")]
    [Authorize(Roles = Role.User)]
    [HttpPost]
    public IActionResult Update([FromBody] BusinessPlan planUpdate) { return prun<BusinessPlan>(_Update, planUpdate); }
    private IActionResult _Update([FromBody] BusinessPlan planUpdate) {
       BusinessPlansRepository repo = new BusinessPlansRepository(context);
       repo.updateLight(uGuid, planUpdate);
       return Ok("Success");
       }

    [HttpGet]
    [Authorize]
    [Route("cashflow/{BusinessPlan}")]
    public ActionResult<CashFlow> Mycashflow(Guid BusinessPlan) { return Prun<Guid, CashFlow>(_Mycashflow, BusinessPlan); }
    private ActionResult<CashFlow> _Mycashflow(Guid planId) {
      var p=new BusinessPlansRepository(context).getPlanBLfull(planId, context.userGuid);
      p.textSupport=new TexterRepository(context);
      return p.myCashFlow(true);
      }

    [HttpGet]
    [Authorize]
    [Route("necessaryCapital/{BusinessPlan}")]
    public ActionResult<List<decimal?>> MynecessaryCapital(Guid BusinessPlan) { return Prun<Guid, List<decimal?>>(_MynecessaryCapital, BusinessPlan); }
    private ActionResult<List<decimal?>> _MynecessaryCapital(Guid planId) {
      var p=new BusinessPlansRepository(context).getPlanBLfull(planId, context.userGuid);
      p.textSupport=new TexterRepository(context);
      return p.refreshNecessaryCapital(false);
      }

    [HttpPost]
    [Authorize]
    [Route("investmentSaveRecalc")]
    public ActionResult<List<decimal?>> MySaveRecalc(StartupInvestments_POST update) { return Prun<StartupInvestments_POST, List<decimal?>>(_MySaveRecalc, update); }
    private ActionResult<List<decimal?>> _MySaveRecalc(StartupInvestments_POST update) {
      update.perform(context);
      return _MynecessaryCapital(update.business_plan_id);
      }

    [HttpPost]
    [Authorize]
    [Route("predict")]
    public async Task<IActionResult> MyPredict(BPpredictP p) { return await prun<BPpredictP>(_MyPredict, p); }
    private async Task<IActionResult> _MyPredict(BPpredictP p) {
      string r=await p.perform(context);
      return Ok(r);
      }

    [HttpGet("doc/{BusinessPlan}")]
    [Authorize]
    //[AllowAnonymous]
    public IActionResult DocFile(Guid BusinessPlan) { return prun<Guid>(_DocFile, BusinessPlan); }
    private IActionResult _DocFile(Guid planId)
    {
        _logger.LogInformation($"-- DocFile for plan {planId}");
            var docFile = new DocFile(context, planId);    
            return File(docFile.stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", docFile.fileName);     
    }

    [HttpPost("docx")]
    [Authorize]
    //[AllowAnonymous]
    public IActionResult DocFilePost([FromBody] ExportPlan plan) { return prun<ExportPlan>(_DocFilePost, plan); }
    private IActionResult _DocFilePost([FromBody] ExportPlan plan)
    {
        _logger.LogInformation($"-- DocpFile for plan {plan.id}");
        //create doc file
        var docFile = new DocFile(context, plan.id,images:plan.images);
        return File(docFile.stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", docFile.fileName);
    }

    [HttpGet("docx/{BusinessPlan}")]
    [Authorize]
    public IActionResult DocxFile(Guid BusinessPlan) { return prun<Guid>(_DocxFile, BusinessPlan); }
    private IActionResult _DocxFile(Guid planId)
    {
        _logger.LogInformation($"-- DocxFile for plan {planId}");
        //create doc file
        var docFile = new DocFile(context, planId);
        var p = new BusinessPlanBL();
        p.textSupport = new TexterRepository(context);
        var fn = p.filePath("_Kabada_export.docx");
        System.IO.File.WriteAllBytes(fn, docFile.stream.ToArray());
        return Ok();
    }

    [HttpGet("pdf/{BusinessPlan}")]
    [Authorize]
    public IActionResult PdfFile(Guid BusinessPlan) { return prun<Guid>(_PdfFile, BusinessPlan); }
    private IActionResult _PdfFile(Guid planId)
    {
        _logger.LogInformation($"-- PdfFile for plan {planId}");                                   
        var docFile = new DocFile(context, planId);
        var temp = docFile.ToPdf();            
        return File(temp, "application/pdf", Path.ChangeExtension(docFile.fileName, ".pdf"));           
    }

    private FileStreamResult xlsR(MemoryStream ms, string outfile){ return File(ms, CashFlow.XLSXmedia, outfile); }

    private FileContentResult xlsR(byte[] cnt, string outfile){ return File(cnt, CashFlow.XLSXmedia, outfile); }
      
    [HttpGet("xlsx/{BusinessPlan}")]
   // [AllowAnonymous]
    [Authorize]
    public IActionResult CashFlowFile(Guid BusinessPlan) { return prun<Guid>(_CashFlowFile, BusinessPlan); }
    private IActionResult _CashFlowFile(Guid planId) {
      var u=context.userGuid;
      if(u==Guid.Empty)
        u=Guid.Parse("{C1F7DC07-FFC7-4B20-B966-08D9BB1CD004}");
      var p=new BusinessPlansRepository(context).getPlanBLfull(planId,u);
      p.textSupport=new TexterRepository(context);

      var skipXlsxFile=true;
      var skipCSV=true;
      var skipCapitalUpdate=false;
      
      var nam=$"Kabada_export_{p.o.Title}.xlsx";
      if(skipXlsxFile)
        return xlsR(p.xlsxStream(skipCSV, skipCapitalUpdate), nam);
       else
        return xlsR(p.xlsxBytes(skipCSV, skipCapitalUpdate), nam);
      //return File(temp, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Kabada_export_{p.o.Title}.xlsx");           
    }

    [HttpGet("startAItraining")]
    [AllowAnonymous]
   // [Authorize]
// THIS IS TEMPORARY for AI debugging purposes ONLY. Should later go to the scheduled tasks.
    public async Task<IActionResult> startAItraining() { return await grun(_startAItraining); }
    private async Task<IActionResult> _startAItraining(){
      await new AIlearnP().learn(context);
      return Ok();
    }

  }
}