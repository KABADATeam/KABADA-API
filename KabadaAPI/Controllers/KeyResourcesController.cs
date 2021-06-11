using KabadaAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KabadaAPI.Controllers {
  [Route("api/kRes")]
  [ApiController]
  public class KeyResourcesController : KController {
    public KeyResourcesController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    [HttpGet]
    [Route("categories")]
    public IActionResult Categories() { return grun(_Categories); }
    private IActionResult _Categories() {
      var r=new ResourceCategories();
      r.read(config, _logger);
      return Ok(r);
      }
    }
  }
