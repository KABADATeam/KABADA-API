using System;
namespace KabadaAPI.DataSource.Repositories
{
    public class BaseRepository : IDisposable
    {
        protected readonly Context context;

        protected BaseRepository()
        {
            context = new Context();
        }

        public void Dispose()
        {
            context.SaveChanges();
            context?.Dispose();
        }
    }
}
