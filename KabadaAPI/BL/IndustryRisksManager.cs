using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KabadaAPI {
  public class IndustryRisksManager : Blotter {
    protected DAcontext daContext;

    public IndustryRisksManager(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext) {
      if(dContext==null)
        this.daContext = new DAcontext(_config, bCcontext.logger);
       else
        this.daContext=dContext;
       }

    public IndustryRisksManager(IConfiguration configuration, ILogger<BackgroundJobber> logger, DAcontext dContext=null) : this(new BLontext(configuration, logger), dContext) {}

    public string getTheOldiest(string fullDirectoryPath, string pattern="*_IR.csv"){      
      var f=new DirectoryInfo(fullDirectoryPath).GetFiles(pattern).OrderBy(f => f.LastWriteTime).FirstOrDefault();
      if (f != null) return f.FullName; // return full path for the found
      return null; // nothing found
      }

    public void proccessCsvFiles(string fullDirectoryPath){
      while(true){
        var f=getTheOldiest(fullDirectoryPath);
        if(f==null)
          break;
        processSingleFile(fullDirectoryPath, f);
        }
      }

    private bool isDelete;
    private List<Guid> myIndustries;
    private List<Guid> myActivities;
    
    private void processSingleFile(string fullDirectoryPath, string f) {
      var start=DateTime.UtcNow;
      var stmp=start.ToString("yyyy.MM.dd.HH.mm.ss");
      var basic=Path.GetFileName(f);
      var suba=Path.Combine(fullDirectoryPath, "Done");
      var lgn=Path.Combine(suba, stmp+"_"+basic+".err");
      var success=false;
      using(var lgf=new StreamWriter(lgn, false, System.Text.Encoding.UTF8)){
        try {
          success=true;
          }
        catch (Exception e) {
           throw;
          }
        lgf.Close();
        }
      // file name ---> (set/DEL, List<isIndustry, i/a Guid>)
      // load scsv. if good, save to a Texter
      // create pointers to texter
      // remove not referenced texters
      throw new System.NotImplementedException();
      }
    }
  }
