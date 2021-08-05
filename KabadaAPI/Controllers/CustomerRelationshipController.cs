using Kabada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
  }
