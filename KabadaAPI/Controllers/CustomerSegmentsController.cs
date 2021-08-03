using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KabadaAPI.Controllers {
  [Route("api/custSegs")]
  [ApiController]
  public class CustomerSegmentsController : KController {
    public CustomerSegmentsController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

   [Route("codifiers")]
   [HttpGet]
        public ActionResult<CustomerSegmentsCodifiers> Categories() { return Grun<CustomerSegmentsCodifiers>(_Categories); }
        private ActionResult<CustomerSegmentsCodifiers> _Categories()
        {
            var r = new CustomerSegmentsCodifiers();
            r.read(context);
            return r;
        }
    }
  }
