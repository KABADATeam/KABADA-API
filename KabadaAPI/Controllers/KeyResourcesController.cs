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
    [Authorize]
    [HttpGet]
    public IActionResult Categories() { return grun(_Categories); }
    private IActionResult _Categories() {
      var r=new ResourceCategories();
      r.read(config, _logger);
      return Ok(r);
      }

    [HttpGet]
    [Authorize]
    [Route("{planId}/1")]
    public IActionResult MyCategories(Guid planId) { return prun<Guid>( _MyCategories, planId); }
    private IActionResult _MyCategories(Guid planId) {
      var r=new ResourceCategories();
      r.read1(planId, config, _logger);
      return Ok(r);
      }
    }
  }
