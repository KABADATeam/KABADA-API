using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace KabadaAPI.Controllers {
  [Route("api/custRel")]
  [ApiController]
  public class CustomerRelationshipController : KController {
    public CustomerRelationshipController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

        [Route("categories")]
        [HttpGet]
        public ActionResult<CustomerRelationshipActions> Categories() { return Grun<CustomerRelationshipActions>(_Categories); }
        private ActionResult<CustomerRelationshipActions> _Categories()
        {
            var r = new CustomerRelationshipActions();
            r.read(context);
            return r;
        }

    [HttpPost]
    [Authorize]
    [Route("save")]
    public ActionResult<Guid> Save(CustomerRelationshipPOST update) { return Prun<CustomerRelationshipPOST, Guid>(_Save, update); }
    private ActionResult<Guid> _Save(CustomerRelationshipPOST update) {
      Guid r=update.perform(context);
      return r;
      }
    }
  }
