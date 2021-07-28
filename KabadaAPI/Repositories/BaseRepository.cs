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

    protected List<BaseRepository> exportOrder { get { return deleteBaseOrder; }}

    protected List<BaseRepository> deleteOrder { get {
      var r=new List<BaseRepository>(){ new RefreshTokenRepository(blContext, daContext) };
      r.AddRange(deleteBaseOrder);
      return r;
      }}

    protected List<BaseRepository> importOrder { get { var r=deleteBaseOrder; r.Reverse(); return r; }}

    internal string snap(string key) {
      //TODO: key validation
      var dirname=$"snap-{DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss")}";
      var path = Directory.GetCurrentDirectory();  
      var opa=$"{path}\\Logs\\{dirname}";
      Directory.CreateDirectory(opa);
      int k=0;

      //k+=new BusinessPlansRepository(blContext, daContext).snapMe(opa);
      //k+=new CountryRepository(blContext, daContext).snapMe(opa);
      //k+=new IndustryRepository(blContext, daContext).snapMe(opa);
      //k+=new IndustryActivityRepository(blContext, daContext).snapMe(opa);
      //k+=new LanguagesRepository(blContext, daContext).snapMe(opa);
      //k+=new Plan_AttributeRepository(blContext, daContext).snapMe(opa);
      //k+=new SharedPlanRepository(blContext, daContext).snapMe(opa);
      //k+=new TexterRepository(blContext, daContext).snapMe(opa);
      //k+=new UsersRepository(blContext, daContext).snapMe(opa);
      //k+=new UserFilesRepository(blContext, daContext).snapMe(opa);
      //k+=new UserTypesRepository(blContext, daContext).snapMe(opa);
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
      var outf=string.Format($"{opa}\\{nam}.txt", opa);
      int k=0;
      using(var os=new StreamWriter(outf, false, System.Text.Encoding.UTF8)){
        var obi=getAll4snap();
        foreach(var o in obi){
          var jasons=Newtonsoft.Json.JsonConvert.SerializeObject(o, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
          //TODO newline in text
          os.WriteLine(jasons);
          k++;
          }
        os.Close();
        }
      LogInformation($"{nam} snapped {k} records.");
      return k;
      }
    }
}
