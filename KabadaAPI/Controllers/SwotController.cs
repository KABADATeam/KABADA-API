using KabadaAPI.DataSource.Models;
using KabadaAPI.DataSource.Repositories;
using KabadaAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace KabadaAPI.Controllers {
  [Route("api/swot")]
  [ApiController]
  public class SwotController : KController {
    public SwotController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    protected TexterRepository tRepo { get { return new TexterRepository(config, _logger); }}
    protected Plan_SWOTRepository psRepo { get { return new Plan_SWOTRepository(config, _logger); }}
    protected BusinessPlansRepository pRepo { get { return new BusinessPlansRepository(config, _logger); }}

    [HttpGet]
    [Route("{BusinessPlan}")]
    public IActionResult GetByKey(Guid planId) { return prun<Guid>(_GetByKey, planId); }
    private IActionResult _GetByKey(Guid planId) {
      var r=new PlanSwots();
      DataSource.Models.BusinessPlan p =pRepo.GetPlan(planId);
     r.is_swot_completed=p.IsSwotCompleted;
      var speci=psRepo.get(planId).ToDictionary(x=>x.TexterId);
      var visi=tRepo.get(planId);
      Plan_SWOT v=null;
      foreach(var x in visi){
        var o=new Swoter(){ description=x.LongValue, id=x.Id, kind_type=x.Kind, title=x.Value, value=0 };
        if(speci.TryGetValue(x.Id, out v))
          o.value=v.Kind;
        if(x.Kind<(int)TexterRepository.EnumTexterKind.oportunity)
          r.strengths_weakness_items.Add(o);
         else
          r.oportunities_threats.Add(o);
        }
      return Ok(r);
      }
    }
  }
