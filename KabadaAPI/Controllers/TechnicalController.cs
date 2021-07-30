using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KabadaAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class TechnicalController : KController {
    private IHostApplicationLifetime lft;
    public TechnicalController(ILogger<KController> logger, IConfiguration configuration, IHostApplicationLifetime lifetime) : base(logger, configuration) { lft=lifetime; }

    internal const string ActualKey="piu pieejas pārbaudīte";

    [AllowAnonymous]
    [Route("snap")]
    [HttpPost]
        public IActionResult Snap([FromBody] string key){ return prun<string>(_snap, key); }
        private IActionResult _snap(string key){
        var t=new UsersRepository(context); // use this because the BaseRepository is abstract
        var r=t.snap(key);
        lft.StopApplication();
        return Ok("Success:"+r);
        }

    [AllowAnonymous]
    [Route("reinitialize")]
    [HttpPost]
        public IActionResult Reinitialize([FromBody] string key){ return prun<string>(_reinitialize, key); }
        private IActionResult _reinitialize(string key){
        var t=new UsersRepository(context); // use this because the BaseRepository is abstract
        var r=t.reinitialize(key, null, true, false);
        return Ok("Success:"+r);
        }
    }
  }
