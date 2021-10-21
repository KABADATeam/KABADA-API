using Kabada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace KabadaAPI.Controllers {
  [Route("quest")]
  [ApiController]
  public class QuestionaireController : KController {
    public QuestionaireController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    [HttpGet]
    [Authorize]
    [Route("personal/{BusinessPlan}")]
    public ActionResult<ChoiceResults> MyPersonalCharacteristics(Guid BusinessPlan) { return Prun<Guid, ChoiceResults>(MyPersonalCharacteristics, BusinessPlan); }
    private ActionResult<ChoiceResults> _MyPersonalCharacteristics(Guid planId){
      var r = new ChoiceResults();
      r.read(context, planId);
      return r;
      }

    [HttpPost]
    [Authorize]
    [Route("personal/save")]
    public IActionResult MyPersonalSave(ChoiceResults update) { return prun<ChoiceResults>(_MyPersonalSave, update); }
    private IActionResult _MyPersonalSave(ChoiceResults update) {
      update.perform(context);
      return Ok();
      }

    }
  }
