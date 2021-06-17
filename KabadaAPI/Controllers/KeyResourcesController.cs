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
    [Route("{BusinessPlan}/1")]
    public IActionResult MyCategories(Guid BusinessPlan) { return prun<Guid>( _MyCategories, BusinessPlan); }
    private IActionResult _MyCategories(Guid planId) {
      var r=new ResourceCategories();
      r.read1(planId, _config, _logger);
      return Ok(r);
      }

    [HttpPost]
    [Route("update")]
    public IActionResult Update(PlanResourcePoster update) { return prun<PlanResourcePoster>(_Update, update); }
    private IActionResult _Update(PlanResourcePoster update) {
      Guid r=update.perform(context);
      return Ok(r);
      }
    }
  }
