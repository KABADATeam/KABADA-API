using Kabada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI.Controllers {
  [Route("api/par")]
  [ApiController]
  public class KeyPartnersController : KController {
    public KeyPartnersController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    [HttpDelete]
    [Authorize]
    [Route("suppl/{resource}")]
    public IActionResult DeleteSuppl(Guid resource) { return prun<Guid>(_DeleteSuppl, resource); }
    private IActionResult _DeleteSuppl(Guid resource) { Plan_AttributeRepository.DeleteAttribute(context, resource, PlanAttributeKind.keySupplier); return Ok("deleted");}

    [HttpDelete]
    [Authorize]
    [Route("distr/{resource}")]
    public IActionResult DeleteDistr(Guid resource) { return prun<Guid>(_DeleteDistr, resource); }
    private IActionResult _DeleteDistr(Guid resource) { Plan_AttributeRepository.DeleteAttribute(context, resource, PlanAttributeKind.keyDistributor); return Ok("deleted"); }

    [HttpDelete]
    [Authorize]
    [Route("other/{resource}")]
    public IActionResult DeleteOther(Guid resource) { return prun<Guid>(_DeleteOther, resource); }
    private IActionResult _DeleteOther(Guid resource) { Plan_AttributeRepository.DeleteAttribute(context, resource, PlanAttributeKind.otherKeyPartner); return Ok("deleted"); }

    [HttpGet]
    [Authorize]
    [Route("{BusinessPlan}")]
    public ActionResult<PlanPartners> MyResources(Guid BusinessPlan) { return Prun<Guid, PlanPartners>( _MyResources, BusinessPlan); }
    private ActionResult<PlanPartners> _MyResources(Guid planId) {
      var r=new PlanPartners();
      r.read(context, planId);
      return r;
      }
    }
  }
