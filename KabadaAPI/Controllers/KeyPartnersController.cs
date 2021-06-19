using Kabada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

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

    [Route("categories")]
    [HttpGet]
    public ActionResult<PlanPartnerTypes> Categories() { return Grun<PlanPartnerTypes>(_Categories); }
    private ActionResult<PlanPartnerTypes> _Categories() {
      var r=new PlanPartnerTypes();
      r.read(context);
      return r;
      }

    [HttpPost]
    [Authorize]
    [Route("suppl/save")]
    public ActionResult<Guid> SaveSupplier(PlanPartnerPoster update) { return Prun<PlanPartnerPoster, Guid>(_SaveSupplier, update); }
    private ActionResult<Guid> _SaveSupplier(PlanPartnerPoster update) {
      Guid r=update.perform(context, PlanAttributeKind.keySupplier, EnumTexterKind.keySuppliers);
      return r;
      }

    [HttpPost]
    [Authorize]
    [Route("distr/save")]
    public ActionResult<Guid> SaveDistributor(PlanPartnerPoster update) { return Prun<PlanPartnerPoster, Guid>(_SaveDistributor, update); }
    private ActionResult<Guid> _SaveDistributor(PlanPartnerPoster update) {
      Guid r=update.perform(context, PlanAttributeKind.keyDistributor, EnumTexterKind.keyDistributors);
      return r;
      }

    [HttpPost]
    [Authorize]
    [Route("other/save")]
    public ActionResult<Guid> SaveOther(PlanPartnerPoster update) { return Prun<PlanPartnerPoster, Guid>(_SaveOther, update); }
    private ActionResult<Guid> _SaveOther(PlanPartnerPoster update) {
      Guid r=update.perform(context, PlanAttributeKind.otherKeyPartner, EnumTexterKind.keyPartnersOther);
      return r;
      }
    }
  }
