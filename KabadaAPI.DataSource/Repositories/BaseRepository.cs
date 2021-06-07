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


        public BaseRepository(IConfiguration config){
          this.config = config;
          context = new Context(config);
          }

        public BaseRepository(IConfiguration config, ILogger logger):this(config) { _logger=logger; } 

        public void Dispose()
        {
            context.SaveChanges();
            context?.Dispose();
        }
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
