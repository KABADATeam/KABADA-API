using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace KabadaAPI {
  public abstract class BaseRepository : Blotter, IDisposable   {
    protected readonly DAcontext daContext;

    public BaseRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext) {
      if(dContext==null)
        this.daContext = new DAcontext(_config);
       else
        this.daContext=dContext;
       }

 //   public BaseRepository(IConfiguration config=null, ILogger logger=null, DAcontext dContext=null) : this(new BLontext(config, logger), dContext) {}

    protected virtual void dispose(){
      daContext.SaveChanges();
      daContext?.Dispose();
      }

    public void Dispose() { dispose(); }

    protected List<BaseRepository> deleteBaseOrder { get { // RefreshTokens not included - must be processed separately
      var r=new List<BaseRepository>();

      r.Add(new Plan_AttributeRepository(blContext, daContext));
      r.Add(new SharedPlanRepository(blContext, daContext));

      r.Add(new BusinessPlansRepository(blContext, daContext));
      r.Add(new TexterRepository(blContext, daContext));

      r.Add(new IndustryActivityRepository(blContext, daContext));
      r.Add(new LanguagesRepository(blContext, daContext));
      r.Add(new CountryRepository(blContext, daContext));
      r.Add(new UsersRepository(blContext, daContext));

      r.Add(new IndustryRepository(blContext, daContext));
      r.Add(new UserTypesRepository(blContext, daContext));

      r.Add(new UserFilesRepository(blContext, daContext));

      return r;
      }}

    protected List<BaseRepository> exportOrder { get { var r=deleteBaseOrder; return r; }}

    protected List<BaseRepository> deleteOrder { get {
      var r=new List<BaseRepository>(){ new RefreshTokenRepository(blContext, daContext) };
      r.AddRange(deleteBaseOrder);
      return r;
      }}

    protected List<BaseRepository> importOrder { get { var r=deleteBaseOrder; r.Reverse(); return r; }}

    internal string snap(string key, string outDirectoryPath=null) {
      //TODO: key validation
      var opa=outDirectoryPath;
      if(opa==null){
        var dirname=$"snap-{DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss")}";
        var path = Directory.GetCurrentDirectory();  
         opa=$"{path}\\Logs\\{dirname}";
        }
      if (!Directory.Exists(opa))  
        Directory.CreateDirectory(opa);
       else {
        var dir = new DirectoryInfo(opa);
        foreach (var file in dir.EnumerateFiles("*.txt"))
          file.Delete();
        }

      int k=0;

      foreach(var o in exportOrder)
        k+=o.snapMe(opa);

      LogInformation($"Total snapped {k} records.");      
      return opa;
      }

    protected virtual object[] getAll4snap(){ return null; }

    protected virtual int snapMe(string opa) {
      var nam=this.GetType().Name;
      var l1=nam.IndexOf("Repository");
      if(l1>0)
        nam=nam.Substring(0, l1);
      var obi=getAll4snap();
      if(obi==null || obi.Length<1){
        LogInformation($"{nam} empty.");
        return 0;
        }
      var outf=string.Format($"{opa}\\{nam}.txt", opa);
      int k=0;
      using(var os=new StreamWriter(outf, false, System.Text.Encoding.UTF8)){
        foreach(var o in obi){
          var jasons=Newtonsoft.Json.JsonConvert.SerializeObject(o, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
          //TODO possible newline in text
          os.WriteLine(jasons);
          k++;
          }
        os.Close();
        }
      LogInformation($"{nam} snapped {k} records.");
      return k;
      }

    internal string reinitialize(string key) {
      //TODO: key validation

      var path = Directory.GetCurrentDirectory();  
      var opa=$"{path}\\DBinit";
      if (!Directory.Exists(opa))  
        throw new Exception("DBinit not present");

      int k=0;
      foreach(var o in deleteOrder)
        k+=o.deleteMe();
      LogInformation($"Total deleted {k} records.");

      k=0;
      foreach(var o in importOrder)
        k+=o.loadMe(opa);
      LogInformation($"Total loaded {k} records.");

      return opa;
      }

    protected virtual int loadMe(string opa) {
      var nam=this.GetType().Name;
      var l1=nam.IndexOf("Repository");
      if(l1>0)
        nam=nam.Substring(0, l1);
      var inf=string.Format($"{opa}\\{nam}.txt", opa);
      if(!File.Exists(inf)){
        LogInformation($"{nam} not present.");
        return 0;
        }
      LogInformation($"{nam} loading.");
      int k=0;
      string ln;  
      using(var os=new StreamReader(inf, System.Text.Encoding.UTF8)){
        while ((ln = os.ReadLine()) != null) {  
          LogInformation(ln);
          loadData(ln);
          daContext.SaveChanges();
          k++; 
          } 
        //if(k>0)
        //  daContext.SaveChanges();
        os.Close();  
        }
      LogInformation($"{nam} loaded {k} records.");
      return k;
      }

    protected virtual string myTable { get { throw new NotImplementedException(GetType().Name+".myTable is not implemented"); }}

    protected virtual int deleteMe() {
      var tableName=myTable;
      var k=daContext.Database.ExecuteSqlRaw("DELETE FROM [" + tableName + "]");
      return k;
      }

    protected virtual void loadData(string json) {  throw new NotImplementedException(GetType().Name+".loadData is not implemented");}
    }
}
