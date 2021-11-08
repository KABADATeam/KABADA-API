using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

namespace KabadaAPI {
  public class IndustryRisksManager : LoaderManager {
    protected TexterRepository tRepo;

    public IndustryRisksManager(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {
      filePattern="*_IR.csv";
      tRepo=new TexterRepository(blContext, daContext);
      }

    public IndustryRisksManager(IConfiguration configuration, ILogger<BackgroundJobber> logger, DAcontext dContext=null) : this(new BLontext(configuration, logger), dContext) {}

    protected override void performSingleInternal(string f, string basic, DateTime start) {
          analyzeRequest(basic);
          if(isDelete)
            performDeletePointers();
           else 
            performLoadAndAddPointers(start, basic, f);
          deleteUnreferenced();
      }

    private bool isDelete;
    private List<Guid?> myIndustries;
    private List<Guid?> myActivities;

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
      log($"{us.Count} pointers of the kind '{kind.ToString()}' set.");
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

    private IndustryActivityRepository iaRepo;
    private IndustryRepository iRepo;
    private void analyzeRequest(string fileName) {
      isDelete=false;
      myIndustries=new List<Guid?>();
      myActivities=new List<Guid?>();

      var pat=fileName.ToUpper();

      string trailer=filePattern.Substring(1).ToUpper(); //"_IR.CSV";
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
      if(pat.Length<1)
        throw new Exception("No targets specified");
      var targets=pat.Split('+');

      iaRepo=new IndustryActivityRepository(blContext);
      iRepo=new IndustryRepository(blContext);

      foreach(var t in targets){
        var mpos=t.IndexOf('-');
        if(mpos<0)
          processElement(t);
         else
          processInterval(t.Substring(0, mpos), t.Substring(mpos+1));
        }
      }

    private bool isIndustry(string element){ return element.Length<2; }

    private Guid findElement(string element){
      if(isIndustry(element)){
        var o=iRepo.byCode(element);
        if(o!=null)
          return o.Id;
       } else {
        var o=iaRepo.byCode(element);
        if(o!=null)
          return o.Id;
       }
      throw new Exception($"Not registered element '{element}'");
      }

    private void processInterval(string v1, string v2) {
      if(v1.Length != v2.Length)
        throw new Exception($"Interval [{v1}-{v2}] with different bound levels not allowed");
      if(string.Compare(v1, v2)!=-1)
        throw new Exception($"Interval [{v1}-{v2}] lower bound must be less than the upper");
      findElement(v1); findElement(v2); // validate presence in DB
      if(isIndustry(v1))
        myIndustries.AddRange(iRepo.interval(v1, v2).Select(x=>(Guid?)x.Id).ToList());
       else
        myActivities.AddRange(iaRepo.interval(v1, v2).Select(x=>(Guid?)x.Id).ToList());
      }

    private void processElement(string t) {
      var x=findElement(t);
      if(isIndustry(t))
        myIndustries.Add(x);
       else
        myActivities.Add(x);
      }
    }
  }
