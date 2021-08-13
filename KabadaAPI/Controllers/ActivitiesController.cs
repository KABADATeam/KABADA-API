﻿using Kabada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

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

    [HttpPost]
    [Authorize]
    [Route("save")]
    public ActionResult<Guid> Save(KeyActivityPost update) { return Prun<KeyActivityPost, Guid>(_Save, update); }
    private ActionResult<Guid> _Save(KeyActivityPost update) {
      Guid r=update.perform(context, uGuid);
      return r;
      }
    }
  }
