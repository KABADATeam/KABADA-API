using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace KabadaAPI {
  public abstract class LoaderManager : Blotter {
    protected DAcontext daContext;
    protected string filePattern;

    public LoaderManager(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext) {
      if(dContext==null)
        this.daContext = new DAcontext(_config, bCcontext.logger);
       else
        this.daContext=dContext;
      }

    public LoaderManager(IConfiguration configuration, ILogger<BackgroundJobber> logger, DAcontext dContext=null) : this(new BLontext(configuration, logger), dContext) {}

    protected StreamWriter lgf;

    protected void logProtocol(string txt){
      if(lgf!=null)
        lgf.WriteLine(txt);
      }

    protected void log(string txt){
      LogInformation(txt);
      logProtocol(txt);
      }

    protected void err(string txt){
      LogError(txt);
      logProtocol(txt);
      }

    protected string initDirectory { get {
      var path = Directory.GetCurrentDirectory();
      return Path.Combine(path, "ImportInit");
      }}

    protected string settingsDirectory { get {
      var r=blContext.importDirectory;
      if(string.IsNullOrWhiteSpace(r))
        return null;
      return r;
      } }

    protected string getTheOldiest(string fullDirectoryPath){      
      var f=new DirectoryInfo(fullDirectoryPath).GetFiles(filePattern).OrderBy(f => f.LastWriteTime).FirstOrDefault();
      if (f != null) return f.FullName; // return full path for the found
      return null; // nothing found
      }

    protected void proccessCsvFiles(string fullDirectoryPath){
      if(!Directory.Exists(fullDirectoryPath))
        throw new Exception($"Import directory '{fullDirectoryPath}' does not exist.");
      while(true){
        var f=getTheOldiest(fullDirectoryPath);
        if(f==null)
          break;
        processSingleFile(fullDirectoryPath, f);
        }
      }

    //public void processInits(){ proccessCsvFiles(initDirectory); }

    //public void processRegulars(){
    //  var t=settingsDirectory;
    //  if(t!=null)
    //    proccessCsvFiles(t);
    //  }

    public void process(bool inits=false){
      var t=inits?initDirectory:settingsDirectory;
      if(t==null)
        return;
      proccessCsvFiles(t);
      }

    protected virtual void performSingleInternal(string f, string basic, DateTime start) {}
    
    private void processSingleFile(string fullDirectoryPath, string f) {
      var start=DateTime.UtcNow;
      var stmp=start.ToString("yyyy.MM.dd.HH.mm.ss");
      var basic=Path.GetFileName(f);
      var suba=Path.Combine(fullDirectoryPath, "Done");
      var lgn=Path.Combine(suba, stmp+"_"+basic+".err");
      var success=false;
      using(lgf=new StreamWriter(lgn, false, System.Text.Encoding.UTF8)){
        try {
          log($"Processing started at {start} UTC.");
          performSingleInternal(f, basic, start);
          //analyzeRequest(basic);
          //if(isDelete)
          //  performDeletePointers();
          // else 
          //  performLoadAndAddPointers(start, basic, f);
          //deleteUnreferenced();
          log($"Processing ended at {DateTime.UtcNow} UTC.");
          success=true;
          }
        catch (Exception exc) {
          err($" crashed: Message='{exc.Message}' StackTrace='{exc.StackTrace}'.");
          var u=exc;
          while(u.InnerException!=null){
            u=u.InnerException;
            err($" crashed(inner): Message='{u.Message}' StackTrace='{u.StackTrace}'.");
            }
          }
        lgf.Close();
        }
      lgf=null;

      // move the processed input file
      var nn=Path.Combine(suba, stmp+"_"+basic);
      File.Move(f, nn);

      if(success){ // rename the log file to indicate success
        var lgg=Path.Combine(suba, stmp+"_"+basic+".log");
        File.Move(lgn, lgg);
        }
      }

    

    public static void Import(BLontext blContext, bool inits=false){
      new IndustryRisksManager(blContext).process(inits);
      new VatManager(blContext).process(inits);
      new EssrManager(blContext).process(inits);
      new TooltipManager(blContext).process(inits);
      }
    }
  }
