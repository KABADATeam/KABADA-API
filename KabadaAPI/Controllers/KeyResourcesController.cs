using Kabada;
using KabadaAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace KabadaAPI.Controllers {
  [Route("api/kres")]
  [ApiController]
  public class KeyResourcesController : KController {
    public KeyResourcesController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    [Route("categories")]
 //   [Authorize]
    [HttpGet]
    public IActionResult Categories() { return grun(_Categories); }
    private IActionResult _Categories() {
      var r=new ResourceCategories();
      r.read(context);
      return Ok(r);
      }

    [HttpGet]
    [Authorize]
    [Route("{BusinessPlan}")]
    public IActionResult MyResources(Guid BusinessPlan) { return prun<Guid>( _MyResources, BusinessPlan); }
    private IActionResult _MyResources(Guid planId) {
      var r=new PlanResources();
      r.read(context, planId);
      return Ok(r);
      }

    [HttpPost]
    [Authorize]
    [Route("update")]
    public IActionResult Update(PlanResourcePoster update) { return prun<PlanResourcePoster>(_Update, update); }
    private IActionResult _Update(PlanResourcePoster update) {
      Guid r=update.perform(context);
      return Ok(r);
      }

    [HttpDelete]
    [Authorize]
    [Route("delete")]
    public IActionResult Delete(Guid resource) { return prun<Guid>(_Delete, resource); }
    private IActionResult _Delete(Guid resource) {
      using(var tr=new Transactioner(context)){
        var aRepo=new Plan_AttributeRepository(context, tr.Context);
        var o=aRepo.byId(resource); 
        var plan=new BusinessPlansRepository(context).GetPlanForUpdate(context.userGuid, o.BusinessPlanId); // only to validate rights on plan
        aRepo.Delete(o);
        tr.Commit();
        }
      return Ok("deleted");
      }
    }
  }
