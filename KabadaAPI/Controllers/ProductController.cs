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

    [Route("types")]
    [HttpGet]
    public IActionResult ProductTypes() { return grun(_ProductTypes); }
    private IActionResult _ProductTypes() {
      var r=new TexterRepository(context).getProductTypeMeta().Select(x=>new { id=x.Id, title=x.Value }).ToList();
      return Ok(r);
    } 
     [Route("features")]
    [HttpGet]
    public IActionResult ProductFeatures() { return grun(_ProductFeatures); }
    private IActionResult _ProductFeatures() {
      var r=new TexterRepository(context).getProductFeatureMeta().Select(x=>new { id=x.Id, title=x.Value }).ToList();
      return Ok(r);
    }
    [Route("incomeSources")]
    [HttpGet]
    public IActionResult IncomeSources() { return grun(_IncomeSources); }
    private IActionResult _IncomeSources() {
      var r=new TexterRepository(context).getProductIncomeSourceMeta().Select(x=>new { id=x.Id, title=x.Value,  }).ToList();
      return Ok(r);
    }
    [Route("priceLevels")]
    [HttpGet]
    public IActionResult PriceLevels() { return grun(_PriceLevels); }
    private IActionResult _PriceLevels() {
      var r=new TexterRepository(context).getProductPriceLevelMeta().Select(x=>new { id=x.Id, level=x.OrderValue, title=x.Value,  }).ToList();
      return Ok(r);
    }
    [Route("innOption")]
    [HttpGet]
    public IActionResult InnovativeOption() { return grun(_InnovativeOption); }
    private IActionResult _InnovativeOption() {
      var r=new TexterRepository(context).getProductInnovativeOptionMeta().Select(x=>new { id=x.Id, level=x.OrderValue, title=x.Value,  }).ToList();
      return Ok(r);
    }
    [Route("qualOption")]
    [HttpGet]
    public IActionResult QualityOption() { return grun(_QualityOption); }
    private IActionResult _QualityOption()
    {
        var r = new TexterRepository(context).getProductQualityOptionMeta().Select(x => new { id = x.Id, level = x.OrderValue, title = x.Value, }).ToList();
        return Ok(r);
    }
    [Route("diffOption")]
    [HttpGet]
    public IActionResult DifferentiationOption() { return grun(_DifferentiationOption); }
    private IActionResult _DifferentiationOption() {
      var r=new TexterRepository(context).getProductDifferentiationOptionMeta().Select(x=>new { id=x.Id, level=x.OrderValue, title=x.Value,  }).ToList();
      return Ok(r);
    }
    }
  }
