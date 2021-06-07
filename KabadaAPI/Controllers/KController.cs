using KabadaAPI.DataSource.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading;

namespace KabadaAPI.Controllers {
  public abstract class KController : ControllerBase {  // KabadaAPI Controller base
    protected readonly IConfiguration config;
    protected readonly ILogger _logger;

    public KController(ILogger logger, IConfiguration configuration){
      config = configuration;
      _logger=logger;     
      }

    protected AppSettings _opt;
    protected AppSettings opt { get {
      if(_opt==null)
        _opt=new AppSettings(config);
      return _opt;
      }}

    protected void LogInformation(string message){
      if(_logger!=null)
        _logger.LogInformation(message);
      }

    protected void LogCritical(string message){
      if(_logger!=null)
        _logger.LogCritical(message);
      }

    protected void LogDebug(string message){
      if(_logger!=null)
        _logger.LogDebug(message);
      }

    protected void LogError(string message){
      if(_logger!=null)
        _logger.LogError(message);
      }

    protected void LogTrace(string message){
      if(_logger!=null)
        _logger.LogTrace(message);
      }

    protected void LogWarning(string message){
      if(_logger!=null)
        _logger.LogWarning(message);
      }

    private static int _sessionId=0;
    private static AppSettings  _sessionIdLocker;

    static KController() {
      _sessionIdLocker=new AppSettings(null);
      }     

    protected Guid uGuid { get { return Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString()); }} // only when logged in


    private int sessionId { get {
      int r=-1;
      lock(_sessionIdLocker){
         r=++_sessionId;
         } 
      return r;
      }}


    protected int           _session;
    
    protected virtual IActionResult grun(Func<IActionResult> actor) {
      IActionResult _result;
      var strt=DateTime.Now;
      try { 
        _session=sessionId;
        var fun=GetType().Name+"."+(new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
        LogInformation($"[{_session}] {fun} started at {strt}.");

        if (!ModelState.IsValid)
          _result=BadRequest("Invalid input");
         else
          _result=actor();

        var t=DateTime.Now;
        LogInformation($"[{_session}] {fun} ended at {t}. duration={t-strt}.");
        }
       catch (Exception exc){
         LogInformation($"[{_session}] crashed.");
         _result=BadRequest(exc.Message);
         }
      return _result;
      }
    
    protected virtual IActionResult prun<T>(Func<T, IActionResult> actor, T parameter) {
      IActionResult _result;
      var strt=DateTime.Now;
      try { 
        _session=sessionId;
        var fun=GetType().Name+"."+(new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
        LogInformation($"[{_session}] {fun} started at {strt}.");

        if (!ModelState.IsValid)
          _result=BadRequest("Invalid input");
         else
          _result=actor(parameter);

        var t=DateTime.Now;
        LogInformation($"[{_session}] {fun} ended at {t}. duration={t-strt}.");
        }
       catch (Exception exc){
         LogInformation($"[{_session}] crashed.");
         _result=BadRequest(exc.Message);
         }
      return _result;
      }

    }
  }
