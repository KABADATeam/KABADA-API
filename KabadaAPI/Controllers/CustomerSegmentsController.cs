using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using static KabadaAPI.Plan_AttributeRepository;

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

    [HttpDelete]
    [Authorize]
    [Route("{segment}")]
    public IActionResult DeleteMe(Guid resource) { return prun<Guid>(_DeleteMe, resource); }
    private IActionResult _DeleteMe(Guid resource) { Plan_SpecificAttributesRepository.DeleteAttribute(context, resource, PlanAttributeKind.customerSegment); return Ok("deleted");}
    }
  }
