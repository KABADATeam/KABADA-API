using Kabada;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI.Controllers {
  [Route("api/languages")]
  [ApiController]
  public class LanguagesController : KController {
    public LanguagesController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

    [HttpGet]
    public ActionResult<List<Language_out>> GetAll() { return Grun<List<Language_out>>(_GetAll); }
    private ActionResult<List<Language_out>> _GetAll() {
      var t=new LanguagesRepository(context).get();
      var r=t.Select(x=>new Language_out { id=x.Id, title=x.Title}).OrderBy(x=>x.title).ToList();
      return r;
        }
    }
  }
