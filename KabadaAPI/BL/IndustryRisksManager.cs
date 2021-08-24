using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

namespace KabadaAPI {
  public class IndustryRisksManager : Blotter {
    protected DAcontext daContext;
    protected StreamWriter lgf;

    protected TexterRepository tRepo;

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
      tRepo=new TexterRepository(blContext, daContext);
      }

    public IndustryRisksManager(IConfiguration configuration, ILogger<BackgroundJobber> logger, DAcontext dContext=null) : this(new BLontext(configuration, logger), dContext) {}

    protected string getTheOldiest(string fullDirectoryPath, string pattern="*_IR.csv"){      
      var f=new DirectoryInfo(fullDirectoryPath).GetFiles(pattern).OrderBy(f => f.LastWriteTime).FirstOrDefault();
      if (f != null) return f.FullName; // return full path for the found
      return null; // nothing found
      }

    protected string initDirectory { get {
      var path = Directory.GetCurrentDirectory();
      return Path.Combine(path, "ImportInit");
      }}

    protected string settingsDirectory { get { return blContext.importDirectory; } }

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

    public void processInits(){ proccessCsvFiles(initDirectory); }

    public void processRegulars(){ proccessCsvFiles(settingsDirectory); }

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

    private int deleteUnreferenced() {
      var usi=new UniversalAttributeRepository(blContext, daContext).usedIRs();
      var k=tRepo.deleteIRs(usi);
      log($"{k} unused texters are removed.");
      return k;
      }

    private List<Guid?> pointBase(){
      var ms=new List<Guid?>();
      ms.AddRange(myIndustries);
      ms.AddRange(myActivities);
      return ms;
      }

    private void performLoadAndAddPointers(DateTime started, string fileName, string fullPath) {
      var l=new IndustryRisksLoader(){ infoReporter=log, errorReporter=err}.load(fullPath);
      if(l==null)
        throw new Exception("CSV load failed.");
      var to=new IndustryRiskDescriptor(){ fileName=fileName, loadStartedUtc=started, risks=l };

      var t=new KabadaAPIdao.Texter(){ Id=Guid.NewGuid(), Kind=(short)EnumTexterKind.industryRisks, Value="", LongValue=to.pack() };
      var ti=t.Id;
      tRepo.create(t);

      var uar=new UniversalAttributeRepository(blContext, daContext);
      var ms=pointBase();
      var oldPointers=uar.byMasters(ms).ToDictionary(x=>x.MasterId);
      makePointers(PlanAttributeKind.industryRiskPointer_industry, myIndustries, oldPointers, uar, ti);
      makePointers(PlanAttributeKind.industryRiskPointer_activity, myActivities, oldPointers, uar, ti);
      }

    private void makePointers(PlanAttributeKind kind, List<Guid?> us, Dictionary<Guid?, KabadaAPIdao.UniversalAttribute> oldPointers, UniversalAttributeRepository uar, Guid target) {
      var k=(short)kind;
      KabadaAPIdao.UniversalAttribute o=null;
      foreach(var x in us){
        if(oldPointers.TryGetValue(x, out o)){
          o.CategoryId=target;
          uar.daContext.SaveChanges();
         } else {
          var y=new KabadaAPIdao.UniversalAttribute(){ AttrVal="", CategoryId=target, Id=Guid.NewGuid(), Kind=k, MasterId=x };
          uar.create(y);
          }
        }
      }

    private void performDeletePointers() {
      var ms=pointBase();
      var k=new UniversalAttributeRepository(blContext, daContext).deleteIRpointers(ms);
      log($"{k} pointers deleted.");
      }


    // industryRisksImportFile::  setFile | deleteFile
    // setFile::                  targets marker
    // deleteFile::               targets '_DEL' marker
    // marker::                   '_IR.csv"
    // targets::                  target [ '+' targets]
    // target::                   element | interval
    // interval::                 element '-' element
    // element::                  letter [ '.' dd [ '.' d [ d ]]]
    // 1. all elements used must be NACE identifiers loaded in the KABADA system
    // 2. interval: the both elements must have the same level and the lower bound must be alphabetically before the upper bound
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
      if(fl>dl && pat.Substring(fl-dl, dl)==deler){
        isDelete=true;
        pat=pat.Substring(0, fl-dl);
        }

      // TODO analyze targets expression from the 'pat' and fill myIndustries + myActivities
      }
    }
  }
