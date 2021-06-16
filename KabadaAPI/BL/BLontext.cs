using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace KabadaAPI {
  public class BLontext : AppSettings {
    public  ILogger   logger { get; protected set; }

    public BLontext(IConfiguration config, ILogger logger=null) : base(config)  { this.logger=logger; }

    public long     sessionId;

    public string     action;

    public Guid       userGuid;

    public void logInformation(string message){
      if(logger!=null)
        logger.LogInformation(message);
      }

    public void logCritical(string message){
      if(logger!=null)
        logger.LogCritical(message);
      }

    public void logDebug(string message){
      if(logger!=null)
        logger.LogDebug(message);
      }

    public void logError(string message){
      if(logger!=null)
        logger.LogError(message);
      }

    public void logTrace(string message){
      if(logger!=null)
        logger.LogTrace(message);
      }

    public void logWarning(string message){
      if(logger!=null)
        logger.LogWarning(message);
      }

    public string autoM { get { return $"[{sessionId}] {action}"; }}
    }
  }
