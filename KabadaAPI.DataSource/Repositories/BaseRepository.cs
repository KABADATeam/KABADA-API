using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace KabadaAPI.DataSource.Repositories
{
    public class BaseRepository : IDisposable
    {
        protected readonly IConfiguration config;
        protected readonly Context context;
        protected readonly ILogger _logger;

        public BaseRepository(IConfiguration config=null, ILogger logger=null, Context context=null) {
          this.config = config;
          _logger=logger;
          if(context==null)
            this.context = new Context(config);
           else
            this.context=context;
          } 

        protected virtual void dispose(){
          context.SaveChanges();
          context?.Dispose();
          }

        public void Dispose() { dispose(); }

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
    }
}
