using Kabada;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KabadaAPI.Controllers {
  [Route("api/activities")]
  [ApiController]
  public class ActivitiesController : KController {
    public ActivitiesController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    [Route("categories")]
    [HttpGet]
    public ActionResult<ActivitiesTypes> Categories() { return Grun<ActivitiesTypes>(_Categories); }
      private ActionResult<ActivitiesTypes> _Categories(){
        var r = new ActivitiesTypes();
        r.read(context);
        return r;
        }
    }
  }
