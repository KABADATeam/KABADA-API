using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static KabadaAPI.TexterRepository;

namespace KabadaAPI {
  public class IndustryRisksManager : Blotter {
    protected DAcontext daContext;
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

    protected string initDirectory { get {
      var path = Directory.GetCurrentDirectory();
      return Path.Combine(path, "ImportInit");
      }}

    protected void proccessCsvFiles(string fullDirectoryPath){
      while(true){
        var f=getTheOldiest(fullDirectoryPath);
        if(f==null)
          break;
        processSingleFile(fullDirectoryPath, f);
        }
      }

    public void processInits(){ proccessCsvFiles(initDirectory); }

    private bool isDelete;
    private List<Guid?> myIndustries;
    private List<Guid?> myActivities;
    
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
          analyzeRequest(basic);
          if(isDelete)
            performDeletePointers();
           else 
            performLoadAndAddPointers(start, basic, f);
          deleteUnreferenced();
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

    private void deleteUnreferenced() {
      throw new NotImplementedException();
      }

    private void performLoadAndAddPointers(DateTime started, string fileName, string fullPath) {
      var l=new IndustryRisksLoader(){ infoReporter=log, errorReporter=err}.load(fullPath);
      var to=new IndustryRiskDescriptor(){ fileName=fileName, loadStartedUtc=started, risks=l };

      var t=new KabadaAPIdao.Texter(){ Id=Guid.NewGuid(), Kind=(short)EnumTexterKind.industryRisks, Value="", LongValue=to.pack() };
      var ti=t.Id;
      new TexterRepository(blContext, daContext).create(t);

      var uar=new UniversalAttributeRepository(blContext, daContext);
      var ms=new List<Guid?>();
      ms.AddRange(myIndustries);
      ms.AddRange(myActivities);
      var oldPointers=uar.byMasters(ms).ToDictionary(x=>x.MasterId);
      KabadaAPIdao.UniversalAttribute o=null;
      foreach(var x in myIndustries){
        if(oldPointers.TryGetValue(x, out o)){
         } else {
          }
        }
      }

    private void performDeletePointers() {
      throw new NotImplementedException();
      }

    private void analyzeRequest(string fileName) {
      isDelete=false;
      myIndustries=new List<Guid?>();
      myActivities=new List<Guid?>();

      var pat=fileName.ToUpper();

      const string trailer="_IR.CSV";
      var tl=trailer.Length;
      var fl=pat.Length;
      if(fl<1+tl || pat.Substring(fl-tl, tl)!=trailer)
        throw new Exception($"Invalid file name '{fileName}'");
      pat=pat.Substring(0, fl-tl);

      const string deler="_DEL";
      fl=pat.Length;
      var dl=deler.Length;
      if(fl>dl && pat.Substring(fl-dl, dl)==trailer){
        isDelete=true;
        pat=pat.Substring(0, fl-dl);
        }

      // TODO analyze targets expression from the 'pat'
      }
    }
  }
