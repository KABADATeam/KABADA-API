using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KabadaAPI {
  public class BackgroundJobber : IWorker {
    private readonly BLontext blC;
    private static DateTime notification;

    public static void Notify(){ notification=DateTime.Now; }
 
    public BackgroundJobber(IConfiguration configuration, ILogger<BackgroundJobber> logger) {
      blC=new BLontext(configuration,logger);
      }
 
    public async Task DoWork(CancellationToken cancellationToken){
      var s=new AppSettings(blC.config);
      var lastRun=new DateTime(1958, 9, 28);
      var scanningStep=(int)(s.jobsNotifyRescanInterval.TotalMilliseconds);
      var rescanInterval=s.jobsRescanInterval;

      while(true){
        await Task.Delay(scanningStep);  // give time to fill in log file parameters at sturtup 
        if(cancellationToken.IsCancellationRequested)
          break;
        var w=DateTime.Now;
        if(notification>lastRun || lastRun.Add(rescanInterval)<=w){
          lastRun=w;
          new JobRepository(blC).runAll();
          }
        if(cancellationToken.IsCancellationRequested)
          break;
        }
      }
    }
  }
