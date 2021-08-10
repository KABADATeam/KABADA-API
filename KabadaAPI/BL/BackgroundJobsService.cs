using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
 
namespace KabadaAPI {
    public class BackgroundJobsService : BackgroundService {
      private readonly IWorker worker;
 
      public BackgroundJobsService(IWorker worker) { this.worker = worker; }
 
      protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        await worker.DoWork(stoppingToken);    
        }
    }
}