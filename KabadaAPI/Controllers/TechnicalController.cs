using Kabada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class TechnicalController : KController {
    private IHostApplicationLifetime lft;
    public TechnicalController(ILogger<KController> logger, IConfiguration configuration, IHostApplicationLifetime lifetime) : base(logger, configuration) { lft=lifetime; }

    internal const string ActualKey="piu pieejas pārbaudīte";

    //[AllowAnonymous]
    //[Route("snap")]
    //[HttpPost]
    //    public IActionResult Snap([FromBody] string key){ return prun<string>(_snap, key); }
    //    private IActionResult _snap(string key){
    //    var t=new UsersRepository(context); // use this because the BaseRepository is abstract
    //    var r=t.snap(key);
    //    lft.StopApplication();
    //    return Ok("Success:"+r);
    //    }

    //[AllowAnonymous]
    //[Route("reinitialize")]
    //[HttpPost]
    //    public IActionResult Reinitialize([FromBody] string key){ return prun<string>(_reinitialize, key); }
    //    private IActionResult _reinitialize(string key){
    //    var t=new UsersRepository(context); // use this because the BaseRepository is abstract
    //    var r=t.reinitialize(key, null, true, false);
    //    return Ok("Success:"+r);
    //    }

    [AllowAnonymous]
    [Route("piu")]
    [HttpPost]
        public IActionResult Piu([FromBody] string parameter){ return prun<string>(_piu, parameter); }
        private IActionResult _piu(string parameter){
        var stp=new Piu(context).go(parameter);
        if(stp)
          lft.StopApplication();
        return Ok("OK");
        }

    [AllowAnonymous]
    [Route("tooltips")]
    [HttpGet]
    public ActionResult<List<Tooltip>> Tooltips() { return Grun<List<Tooltip>>(_Tooltips); }
    private ActionResult<List<Tooltip>> _Tooltips() {
      return new TooltipManager(context).load();
      }

    [Authorize(Roles = Role.User)]
    [Route("test/{BusinessPlan}")]
    [HttpGet]
    public ActionResult<UnloadSet> test(Guid BusinessPlan) { return Prun<Guid, UnloadSet>(_test, BusinessPlan); }
    private ActionResult<UnloadSet> _test(Guid iddddd) {
      UnloadSet r=null;
      var br=new BusinessPlansRepository(context);

//      br.clone(iddddd, true);

      var pubi = br.GetPlans(context.userGuid).Select(x => x.Id).ToList();
      foreach (var planId in pubi)
        br.clone(planId, true);
      return r;
      }
    }
  }
