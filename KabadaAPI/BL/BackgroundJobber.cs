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
      var lastAI = lastRun;
      var AIrescan=new TimeSpan(22, 0, 0);
      var AIpoint=s.aiTeachPoint;

      while (true){
        try {
          await Task.Delay(scanningStep);  // give time to fill in log file parameters at sturtup 
          if (cancellationToken.IsCancellationRequested)
            break;
          var w = DateTime.Now;
          var o= new JobRepository(blC);
          if (notification>lastRun || lastRun.Add(rescanInterval)<=w) {
            lastRun=w;
            o.runAll();
            }
          if (cancellationToken.IsCancellationRequested)
            break;
          if(AIpoint!=null && lastAI.Add(AIrescan) <= w){
            var t0=new DateTime(w.Year, w.Month, w.Day).Add(AIpoint.Value);
            if(w>=t0 && t0.Add(rescanInterval)>w){
              lastAI=w;
              await o.teachAI();
              }
            }
          }
        catch (Exception e) { MIX.EXC(blC.logError, e, "BackgroundJobber "); }
        }
      }
    }
  }
