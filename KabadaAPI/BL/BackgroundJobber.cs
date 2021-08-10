using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace KabadaAPI {
  public class BackgroundJobber : IWorker {
    private readonly BLontext blC;
 
    public BackgroundJobber(IConfiguration configuration) {
      blC=new BLontext(configuration,null);
      }
 
    public async Task DoWork(CancellationToken cancellationToken){
      while (!cancellationToken.IsCancellationRequested){
        new JobRepository(blC).runAll();
        await Task.Delay(1000 * 5);
        }
      }
    }
  }
