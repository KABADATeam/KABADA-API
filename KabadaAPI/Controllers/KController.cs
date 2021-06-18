using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace KabadaAPI.Controllers {
  public abstract class KController : ControllerBase {  // KabadaAPI Controller base
    public BLontext context { get; private set; }

    public KController(ILogger logger, IConfiguration configuration){ context=new BLontext(configuration, logger); }

    //------------------logging---------------------------------------------------//
    protected ILogger _logger { get { return context.logger; }}
    protected void LogInformation(string message){ context.logInformation(message); }
    protected void LogCritical(string message){ context.logCritical(message); }
    protected void LogDebug(string message){ context.logDebug(message); }
    protected void LogError(string message){ context.logError(message); }
    protected void LogTrace(string message){ context.logTrace(message); }
    protected void LogWarning(string message){  context.logWarning(message); }



    protected IConfiguration _config { get { return context.config; }}

    //------------------ sessionID ------------------------------------//
    private static long _sessionId=0;
    private static AppSettings  _sessionIdLocker;
    static KController() { _sessionIdLocker=new AppSettings(null); }     

    private long generateSessionId { get {
      long r=-1;
      lock(_sessionIdLocker){
         r=++_sessionId;
         } 
      return r;
      }}

    private void setUguid(){
      if(User==null)
        return;
      var t=User.FindFirst(ClaimTypes.Name);
      if(t==null)
        return;
      var w=t.Value.ToString();
      if(string.IsNullOrWhiteSpace(w))
        return;
      context.userGuid=Guid.Parse(w);
      }
    protected Guid uGuid { get { return context.userGuid;  }} //    Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString()); }} // only when logged in

    protected IActionResult _result;

    protected void crash(Exception exc){
      LogError(context.autoM+$" crashed: Message='{exc.Message}' StackTrace='{exc.StackTrace}'.");
      _result=BadRequest(exc.Message);
      }

    private DateTime strt;

    private void part1(){
      strt=DateTime.Now;
      context.sessionId=generateSessionId;
      context.action=GetType().Name+"."+(new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
      context.logInformation(context.autoM+$" started at {strt}.");
      setUguid();
      }

    private void part2(){
        var t=DateTime.Now;
        context.logInformation(context.autoM+$" ended at {t}. duration={t-strt}.");
      }

    protected virtual ActionResult<Tr> Grun<Tr>(Func<ActionResult<Tr>> actor) {
      ActionResult<Tr> _result=null;
      try {
        part1();
        if (!ModelState.IsValid)
          _result=BadRequest("Invalid input");
         else
          _result=actor();
        part2();
        }
       catch (Exception exc){ crash(exc); }
      return _result;
      }
    
    protected virtual IActionResult grun(Func<IActionResult> actor) {
      try {
        part1();
        if (!ModelState.IsValid)
          _result=BadRequest("Invalid input");
         else
          _result=actor();
        part2();
        }
       catch (Exception exc){ crash(exc); }
      return _result;
      }

    protected virtual async Task<IActionResult> grun(Func<Task<IActionResult>> actor) {
      try {
        part1();
        if (!ModelState.IsValid)
          _result=BadRequest("Invalid input");
         else
          _result=await actor();
        part2();
        }
       catch (Exception exc){ crash(exc); }
      return _result;
      }

    protected virtual async Task<ActionResult<Tr>> Grun<Tr>(Func<Task<ActionResult<Tr>>> actor) {
      ActionResult<Tr> _result=null;
      try {
        part1();
        if (!ModelState.IsValid)
          _result=BadRequest("Invalid input");
         else
          _result=await actor();
        part2();
        }
       catch (Exception exc){ crash(exc); }
      return _result;
      }
   
    protected virtual IActionResult prun<T>(Func<T, IActionResult> actor, T parameter) {
      try { 
        part1();
        if (!ModelState.IsValid)
          _result=BadRequest("Invalid input");
         else
          _result=actor(parameter);
        part2();
        }
       catch (Exception exc){ crash(exc); }
      return _result;
      }
    
    protected async virtual Task<IActionResult> prun<T>(Func<T, Task<IActionResult>> actor, T parameter) {
      try { 
        part1();
        if (!ModelState.IsValid)
          _result=BadRequest("Invalid input");
         else
          _result=await actor(parameter);
        part2();
        }
       catch (Exception exc){ crash(exc); }
      return _result;
      }

    }
  }
