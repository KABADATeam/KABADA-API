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


    internal string snap(string key) {
      //TODO: key validation
      var dirname=$"snap-{DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss")}";
      var path = Directory.GetCurrentDirectory();  
      var opa=$"{path}\\Logs\\{dirname}";
      Directory.CreateDirectory(opa);
      int k=0;

      k+=new BusinessPlansRepository(blContext, daContext).snapMe(opa);
      k+=new CountryRepository(blContext, daContext).snapMe(opa);
      k+=new IndustryRepository(blContext, daContext).snapMe(opa);
      k+=new IndustryActivityRepository(blContext, daContext).snapMe(opa);
      k+=new LanguagesRepository(blContext, daContext).snapMe(opa);
      k+=new Plan_AttributeRepository(blContext, daContext).snapMe(opa);
      k+=new SharedPlanRepository(blContext, daContext).snapMe(opa);
      k+=new TexterRepository(blContext, daContext).snapMe(opa);
      k+=new UsersRepository(blContext, daContext).snapMe(opa);
      k+=new UserFilesRepository(blContext, daContext).snapMe(opa);
      k+=new UserTypesRepository(blContext, daContext).snapMe(opa);

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
