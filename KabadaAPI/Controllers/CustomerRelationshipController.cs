﻿using Kabada;
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

    [HttpDelete]
    [Authorize]
    [Route("{resource}")]
    public IActionResult DeleteMe(Guid resource) { return prun<Guid>(_DeleteMe, resource); }
    private IActionResult _DeleteMe(Guid resource) { Plan_AttributeRepository.DeleteAttribute(context, resource); return Ok("deleted"); }

    [HttpGet]
    [Authorize]
    [Route("{BusinessPlan}")]
    public ActionResult<PlanRelationships> MyRelationships(Guid BusinessPlan) { return Prun<Guid, PlanRelationships>(_MyRelationships, BusinessPlan); }
    private ActionResult<PlanRelationships> _MyRelationships(Guid planId) {
      var r = new PlanRelationships();
      r.read(context, planId);
      return r;
      }
    }
  }
