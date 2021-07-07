using Kabada;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

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
    }
  }
