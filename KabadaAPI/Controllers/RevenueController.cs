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
  [Route("api/revenue")]
  [ApiController]
  public class RevenueController : KController {
    public RevenueController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    protected TexterRepository tRepo { get { return new TexterRepository(context); }}
    protected Plan_AttributeRepository paRepo { get { return new Plan_AttributeRepository(context); }}
    protected BusinessPlansRepository pRepo { get { return new BusinessPlansRepository(context); }}

        [HttpGet]
        [Authorize]
        [Route("{BusinessPlan}")]
        public ActionResult<PlanRevenues> MyRevenues(Guid BusinessPlan) { return Prun<Guid, PlanRevenues>(_MyRevenues, BusinessPlan); }
        private ActionResult<PlanRevenues> _MyRevenues(Guid planId)
        {
            var r = new PlanRevenues();
            r.read(context, planId);
            return r;
        }
        [Route("streamTypes")]
        [HttpGet]
        public ActionResult<RevenueStreamTypes> Categories() { return Grun<RevenueStreamTypes>(_Categories); }
        private ActionResult<RevenueStreamTypes> _Categories()
        {
            var r = new RevenueStreamTypes();
            r.read(context);
            return r;
        }
        [Route("prices")]
        [HttpGet]
        public ActionResult<RevenuePriceTypes> Prices() { return Grun<RevenuePriceTypes>(_Prices); }
        private ActionResult<RevenuePriceTypes> _Prices()
        {
            var r = new RevenuePriceTypes();
            r.read(context);
            return r;
        }

        [HttpDelete]
        [Authorize]
        [Route("{resource}")]
        public IActionResult DeleteMe(Guid resource) { return prun<Guid>(_DeleteMe, resource); }
        private IActionResult _DeleteMe(Guid resource) { Plan_AttributeRepository.DeleteAttribute(context, resource); return Ok("deleted"); }

        [HttpPost]
        [Authorize]
        [Route("save")]
        public ActionResult<Guid> Save(PlanRevenuePoster update) { return Prun<PlanRevenuePoster, Guid>(_Save, update); }
        private ActionResult<Guid> _Save(PlanRevenuePoster update)
        {
            Guid r = update.perform(context);
            return r;
        }
        
    }
}
