using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KabadaAPI {
  public abstract class Blotter {
    protected Blotter(){}
    public BLontext blContext { get; set; }
    protected Blotter(BLontext context) { blContext=context;}

    protected IConfiguration _config { get { return blContext.config; }}

    //------------------logging---------------------------------------------------//
    protected ILogger _logger { get { return blContext.logger; }}
    protected void LogInformation(string message){ if(blContext!=null) blContext.logInformation(message); }
    protected void LogCritical(string message){ if(blContext!=null) blContext.logCritical(message); }
    protected void LogDebug(string message){ if(blContext!=null) blContext.logDebug(message); }
    protected void LogError(string message){ if(blContext!=null) blContext.logError(message); }
    protected void LogTrace(string message){ if(blContext!=null) blContext.logTrace(message); }
    protected void LogWarning(string message){ if(blContext!=null) blContext.logWarning(message); }
    }
  }
