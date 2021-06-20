using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KabadaAPI {
  public abstract class Blotter {
    public BLontext blContext { get; private set; }
    protected Blotter(BLontext context) { blContext=context;}

    protected IConfiguration _config { get { return blContext.config; }}

    //------------------logging---------------------------------------------------//
    protected ILogger _logger { get { return blContext.logger; }}
    protected void LogInformation(string message){ blContext.logInformation(message); }
    protected void LogCritical(string message){ blContext.logCritical(message); }
    protected void LogDebug(string message){ blContext.logDebug(message); }
    protected void LogError(string message){ blContext.logError(message); }
    protected void LogTrace(string message){ blContext.logTrace(message); }
    protected void LogWarning(string message){ blContext.logWarning(message); }
    }
  }
