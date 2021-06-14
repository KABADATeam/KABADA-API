using KabadaAPIdao;
using KabadaAPI.DataSource.Repositories;
using KabadaAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.DataSource.Repositories.TexterRepository;

namespace KabadaAPI.Controllers {
  [Route("api/swot")]
  [ApiController]
  public class SwotController : KController {
    public SwotController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    protected TexterRepository tRepo { get { return new TexterRepository(config, _logger); }}
    //protected Plan_SWOTRepository psRepo { get { return new Plan_SWOTRepository(config, _logger); }}
    protected Plan_AttributeRepository paRepo { get { return new Plan_AttributeRepository(config, _logger); }}
    protected BusinessPlansRepository pRepo { get { return new BusinessPlansRepository(config, _logger); }}

    [HttpGet]
    [Route("{BusinessPlan}")]
    public IActionResult GetByKey(string BusinessPlan) { return prun<string>(_GetByKey, BusinessPlan); }
    private IActionResult _GetByKey(string planId0) {
      Guid planId=new Guid(planId0);
      var r=new PlanSwots();
      var p =pRepo.GetPlan(planId);
      if(p!=null)
        r.is_swot_completed=p.IsSwotCompleted;
      var speci=paRepo.get(planId, Plan_AttributeRepository.PlanAttributeKind.swot).ToDictionary(x=>x.TexterId);
      //var speci=psRepo.get(planId).ToDictionary(x=>x.TexterId);
      var visi=tRepo.getSWOTs(planId);
      Plan_Attribute v=null;
      //Plan_SWOT v=null;
      foreach(var x in visi){
        var o=new Swoter(){ description=x.LongValue, id=x.Id, isLocal=((x.Kind % 2) == 0), title=x.Value, value=0 };
        if(speci.TryGetValue(x.Id, out v))
          o.value=short.Parse(v.AttrVal);
        if(x.Kind<(int)TexterRepository.EnumTexterKind.oportunity)
          r.strengths_weakness_items.Add(o);
         else
          r.oportunities_threats.Add(o);
        }
      return Ok(r);
      }

    [HttpPost]
    [Route("update")]
    public IActionResult Update(PlanSwotUpdate update) { return prun<PlanSwotUpdate>(_Update, update); }
    private IActionResult _Update(PlanSwotUpdate update) {
      var plan=pRepo.GetPlanForUpdate(uGuid, update.business_plan_id);
      update.Perform(config, _logger, plan);
      return Ok("success");
      }
    }
  }
