using Kabada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using static KabadaAPI.Plan_AttributeRepository;
using System.Linq;

namespace KabadaAPI.Controllers {
  [Route("api/product")]
  [ApiController]
  public class ProductController : KController {
    public ProductController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    [HttpGet]
    [Authorize]
    [Route("{BusinessPlan}")]
    public ActionResult<PlanProducts> MyResources(Guid BusinessPlan) { return Prun<Guid, PlanProducts>( _MyResources, BusinessPlan); }
    private ActionResult<PlanProducts> _MyResources(Guid planId) {
      var r=new PlanProducts();
      r.read(context, planId);
      return r;
      }

    [HttpDelete]
    [Authorize]
    [Route("{resource}")]
    public IActionResult DeleteMe(Guid resource) { return prun<Guid>(_DeleteMe, resource); }
    private IActionResult _DeleteMe(Guid resource) { Plan_AttributeRepository.DeleteAttribute(context, resource, PlanAttributeKind.product); return Ok("deleted");}

    [Route("categories")]
    [HttpGet]
    public IActionResult Categories() { return grun(_Categories); }
    private IActionResult _Categories() {
      var r=new TexterRepository(context).getProductMeta().Select(x=>new { id=x.Id, title=x.Value }).ToList();
      return Ok(r);
      }

    }
  }
