using Kabada;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Authorization;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

namespace KabadaAPI.Controllers
{
  [Route("api/cost")]
  [ApiController]
  public class CostController : KController {
    public CostController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    protected TexterRepository tRepo { get { return new TexterRepository(context); }}
    protected Plan_AttributeRepository paRepo { get { return new Plan_AttributeRepository(context); }}
    protected BusinessPlansRepository pRepo { get { return new BusinessPlansRepository(context); }}

    [HttpGet]
    [Authorize]
    [Route("{BusinessPlan}")]
    public ActionResult<PlanCosts> MyCosts(Guid BusinessPlan) { return Prun<Guid, PlanCosts>(_MyCosts, BusinessPlan); }
        private ActionResult<PlanCosts> _MyCosts(Guid planId)
        {
            var r = new PlanCosts();
            r.read(context, planId);
            return r;
        }
        [Route("categories")]
        [HttpGet]
        public ActionResult<CostCategories> Categories() { return Grun<CostCategories>(_Categories); }
        private ActionResult<CostCategories> _Categories()
        {
            var r = new CostCategories();
            r.read(context);
            return r;
        }

        [HttpDelete]
        [Authorize]
        [Route("fixed/{resource}")]
        public IActionResult DeleteFixed(Guid resource) { return prun<Guid>(_DeleteFixed, resource); }
        private IActionResult _DeleteFixed(Guid resource) { Plan_AttributeRepository.DeleteAttribute(context, resource, PlanAttributeKind.fixedCost); return Ok("deleted"); }

        [HttpDelete]
        [Authorize]
        [Route("var/{resource}")]
        public IActionResult DeleteVariable(Guid resource) { return prun<Guid>(_DeleteVariable, resource); }
        private IActionResult _DeleteVariable(Guid resource) { Plan_AttributeRepository.DeleteAttribute(context, resource, PlanAttributeKind.variableCost); return Ok("deleted"); }

        [HttpPost]
        [Authorize]
        [Route("fixed/save")]
        public ActionResult<Guid> SaveFixed(PlanCostPoster update) { return Prun<PlanCostPoster, Guid>(_SaveFixed, update); }
        private ActionResult<Guid> _SaveFixed(PlanCostPoster update)
        {
            Guid r = update.perform(context, PlanAttributeKind.fixedCost, EnumTexterKind.costType);
            return r;
        }
        [HttpPost]
        [Authorize]
        [Route("var/save")]
        public ActionResult<Guid> SaveVariable(PlanCostPoster update) { return Prun<PlanCostPoster, Guid>(_SaveVariable, update); }
        private ActionResult<Guid> _SaveVariable(PlanCostPoster update)
        {
            Guid r = update.perform(context, PlanAttributeKind.variableCost, EnumTexterKind.costType);
            return r;
        }

    [HttpGet]
    [Authorize]
    [Route("costsvf/{BusinessPlan}")]
    public ActionResult<VFcosts> MyVFCosts(Guid BusinessPlan) { return Prun<Guid, VFcosts>(_MyVFCosts, BusinessPlan); }
        private ActionResult<VFcosts> _MyVFCosts(Guid planId)
        {
            var r = new VFcosts();
            r.read(context, planId);
            return r;
        }

    [HttpPost]
    [Authorize]
    [Route("costsvf/save")]
    public ActionResult<Guid> SaveVF(PlanVFCostsPoster update) { return Prun<PlanVFCostsPoster, Guid>(_SaveVF, update); }
    private ActionResult<Guid> _SaveVF(PlanVFCostsPoster update){
      Guid r = update.perform(context);
      return r;
      }
    }
}
