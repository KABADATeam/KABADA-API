﻿using KabadaAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KabadaAPI.Controllers {
  [Route("api/kres")]
  [ApiController]
  public class KeyResourcesController : KController {
    public KeyResourcesController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    [Route("categories")]
    [Authorize]
    [HttpGet]
    public IActionResult Cantegories() { return grun(_Cantegories); }
    private IActionResult _Cantegories() {
      var r=new ResourceCategories();
      r.read(config, _logger);
      return Ok(r);
      }
    }
  }
