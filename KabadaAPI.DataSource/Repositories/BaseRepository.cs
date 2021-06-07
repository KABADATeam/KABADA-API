using Microsoft.Extensions.Configuration;
using System;
namespace KabadaAPI.DataSource.Repositories
{
    public class BaseRepository : IDisposable
    {
        protected readonly IConfiguration config;
        protected readonly Context context;

        public BaseRepository(IConfiguration config){
          this.config = config;
          context = new Context(config);
          }

        public void Dispose()
        {
            context.SaveChanges();
            context?.Dispose();
        }
    }
}
