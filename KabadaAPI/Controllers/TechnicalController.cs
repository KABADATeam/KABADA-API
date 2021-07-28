using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KabadaAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class TechnicalController : KController {
    public TechnicalController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    [AllowAnonymous]
    [Route("snap")]
    [HttpPost]
        public IActionResult Snap([FromBody] string key){ return prun<string>(_snap, key); }
        private IActionResult _snap(string key){
        var t=new UsersRepository(context); // use this because the BaseRepository is abstract
        var r=t.snap(key);
        return Ok("Success:"+r);
        }
    }
  }
