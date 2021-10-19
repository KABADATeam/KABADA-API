using Kabada;
using KabadaAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI.Controllers {
  [Route("api/kres")]
  [ApiController]
  public class KeyResourcesController : KController {
    public KeyResourcesController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    [Route("categories")]
    [HttpGet]
    public ActionResult<ResourceCategories> Categories() { return Grun<ResourceCategories>(_Categories); }
    private ActionResult<ResourceCategories> _Categories() {
      var r=new ResourceCategories();
      r.read(context);
      return r;
      }

    [HttpGet]
    [Authorize]
    [Route("{BusinessPlan}")]
    public ActionResult<PlanResources> MyResources(Guid BusinessPlan) { return Prun<Guid, PlanResources>( _MyResources, BusinessPlan); }
    private ActionResult<PlanResources> _MyResources(Guid planId) {
      var r=new PlanResources();
      r.read(context, planId);
      return r;
      }

    [HttpPost]
    [Authorize]
    [Route("update")]
    public ActionResult<Guid> Update(PlanResourcePoster update) { return Prun<PlanResourcePoster, Guid>(_Update, update); }
    private ActionResult<Guid> _Update(PlanResourcePoster update) {
      Guid r=update.perform(context);
      return r;
      }

    [HttpDelete]
    [Authorize]
    [Route("{resource}")]
    public IActionResult Delete(Guid resource) { return prun<Guid>(_Delete, resource); }
    private IActionResult _Delete(Guid resource) { Plan_AttributeRepository.DeleteAttribute(context, resource, PlanAttributeKind.keyResource); return Ok("deleted");}

    [HttpGet]
    [Authorize]
    [Route("investment/{BusinessPlan}")]
    public ActionResult<StartupInvestments> Myinvestments(Guid BusinessPlan) { return Prun<Guid, StartupInvestments>( _Myinvestments, BusinessPlan); }
    private ActionResult<StartupInvestments> _Myinvestments(Guid planId) {
      var r=new StartupInvestments();
      r.read(context, planId);
      return r;
      }

    [HttpPost]
    [Authorize]
    [Route("investment/update")]
    public IActionResult Updateinvestments(StartupInvestments_POST update) { return prun<StartupInvestments_POST>(_Updateinvestments, update); }
    private IActionResult _Updateinvestments(StartupInvestments_POST update) {
      update.perform(context);
      return Ok();
      }

    [HttpGet]
    [Authorize]
    [Route("assets/{BusinessPlan}")]
    public ActionResult<Assets> MyAssets(Guid BusinessPlan) { return Prun<Guid, Assets>(_MyAssets, BusinessPlan); }
    private ActionResult<Assets> _MyAssets(Guid planId) {
      var r = new Assets();
      r.read(context, planId);
      return r;
      }

    [HttpPost]
    [Authorize]
    [Route("assets/save")]
    public IActionResult MyAssetsSave(Assets_POST update) { return prun<Assets_POST>(_MyAssetsSave, update); }
    private IActionResult _MyAssetsSave(Assets_POST update) {
      update.perform(context);
      return Ok();
      }
    }
  }
