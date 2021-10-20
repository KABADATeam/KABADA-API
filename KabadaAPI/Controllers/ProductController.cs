using Kabada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using static KabadaAPI.Plan_AttributeRepository;
using System.Linq;

namespace KabadaAPI.Controllers {
  [Route("api/products")]
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
    [HttpGet]
    [Authorize]
    [Route("product/{id}")]
    public ActionResult<ProductAttribute> ProductById(Guid id) { return Prun<Guid, ProductAttribute>(_ProductById, id); }
    private ActionResult<ProductAttribute> _ProductById(Guid productId)
    {
        var r = new Plan_AttributeRepository(context).byId(productId);
        var pr = new ProductAttribute(); pr.unpack(r.AttrVal);
        return pr;
    }
    [HttpDelete]
    [Authorize]
    [Route("{resource}")]
    public IActionResult DeleteMe(Guid resource) { return prun<Guid>(_DeleteMe, resource); }
    private IActionResult _DeleteMe(Guid resource) {
      Plan_AttributeRepository.DeleteProduct(context, resource); return Ok("deleted");
      }

    [HttpDelete]
    [Authorize]
    [Route("cascade/{resource}")]
    public IActionResult DeleteMeC(Guid resource) { return prun<Guid>(_DeleteMeC, resource); }
    private IActionResult _DeleteMeC(Guid resource) {
      Plan_AttributeRepository.DeleteProduct(context, resource, true); return Ok("deleted");
      }

    [Route("types")]
    [HttpGet]
    public IActionResult ProductTypes() { return grun(_ProductTypes); }
    private IActionResult _ProductTypes() {
      var r=new TexterRepository(context).getProductTypeMeta().Select(x=>new CodifierBase(){ id=x.Id, title=x.Value }).ToList();
      return Ok(r);
    } 
     [Route("features")]
    [HttpGet]
    public IActionResult ProductFeatures() { return grun(_ProductFeatures); }
    private IActionResult _ProductFeatures() {
      var r=new TexterRepository(context).getProductFeatureMeta().Where(x=>x.Name!=TexterRepository.BLOCK).Select(x=>new CodifierNamed() { id=x.Id, title=x.Value, name=x.Name }).ToList();
      return Ok(r);
    }
    [Route("incomeSources")]
    [HttpGet]
    public IActionResult IncomeSources() { return grun(_IncomeSources); }
    private IActionResult _IncomeSources() {
      var r=new TexterRepository(context).getProductIncomeSourceMeta().Select(x=>new CodifierBase() { id=x.Id, title=x.Value,  }).ToList();
      return Ok(r);
    }
    [Route("priceLevels")]
    [HttpGet]
    public IActionResult PriceLevels() { return grun(_PriceLevels); }
    private IActionResult _PriceLevels() {
      var r=new TexterRepository(context).getProductPriceLevelMeta().Select(x=>new CodifierBase() { id=x.Id, level=x.OrderValue, title=x.Value,  }).ToList();
      return Ok(r);
    }
    [Route("innOptions")]
    [HttpGet]
    public IActionResult InnovativeOptions() { return grun(_InnovativeOptions); }
    private IActionResult _InnovativeOptions() {
      var r=new TexterRepository(context).getProductInnovativeOptionMeta().Select(x=>new CodifierBase() { id=x.Id, level=x.OrderValue, title=x.Value,  }).ToList();
      return Ok(r);
    }
    [Route("qualOptions")]
    [HttpGet]
    public IActionResult QualityOptions() { return grun(_QualityOptions); }
    private IActionResult _QualityOptions()
    {
        var r = new TexterRepository(context).getProductQualityOptionMeta().Select(x => new CodifierBase() { id = x.Id, level = x.OrderValue, title = x.Value, }).ToList();
        return Ok(r);
    }
    [Route("diffOptions")]
    [HttpGet]
    public IActionResult DifferentiationOptions() { return grun(_DifferentiationOptions); }
    private IActionResult _DifferentiationOptions() {
      var r=new TexterRepository(context).getProductDifferentiationOptionMeta().Select(x=>new CodifierBase() { id=x.Id, level=x.OrderValue, title=x.Value,  }).ToList();
      return Ok(r);
    }
        [HttpPost]
        [Authorize]
        [Route("update")]
        public ActionResult<Guid> Update(PlanProductPoster update) { return Prun<PlanProductPoster, Guid>(_Update, update); }
        private ActionResult<Guid> _Update(PlanProductPoster update)
        {
            Guid r = update.perform(context);
            return r;
        }

    [HttpGet]
    [Authorize]
    [Route("salesforecasts/{BusinessPlan}")]
    public ActionResult<PlanSalesForecasts> MyForecasts(Guid BusinessPlan) { return Prun<Guid, PlanSalesForecasts>( _MyForecasts, BusinessPlan); }
    private ActionResult<PlanSalesForecasts> _MyForecasts(Guid planId) {
      var r=new PlanSalesForecasts();
      r.read(context, planId);
      return r;
      }

    [HttpPost]
    [Authorize]
    [Route("salesforecasts/update")]
    public IActionResult SFupdate(ProductsSalesForecastPOST update) { return prun<ProductsSalesForecastPOST>(_SFupdate, update); }
    private IActionResult _SFupdate(ProductsSalesForecastPOST update) {
      update.perform(context);
      return Ok();
      }
    }
}
