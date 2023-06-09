﻿using Kabada;
using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KabadaAPI {
  public abstract class BaseRepository : Blotter, IDisposable   {
    internal DAcontext daContext;

    public BaseRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext) {
      if(dContext==null)
        this.daContext = new DAcontext(_config, bCcontext.logger);
       else
        this.daContext=dContext;
       }

    protected BaseRepository(){}
 //   public BaseRepository(IConfiguration config=null, ILogger logger=null, DAcontext dContext=null) : this(new BLontext(config, logger), dContext) {}

    protected virtual void dispose(){
      daContext.SaveChanges();
      daContext?.Dispose();
      }

    public void Dispose() { dispose(); }

    protected List<BaseRepository> getDeleteBaseOrder(DAcontext daContext=null) { 
      var r=new List<BaseRepository>();

      r.Add(new UniversalAttributeRepository(blContext, daContext));
      r.Add(new Plan_AttributeRepository(blContext, daContext));
      r.Add(new SharedPlanRepository(blContext, daContext));
      r.Add(new Plan_SpecificAttributesRepository(blContext, daContext));

      r.Add(new BusinessPlansRepository(blContext, daContext));
      r.Add(new TexterRepository(blContext, daContext));
      r.Add(new JobRepository(blContext, daContext));

      r.Add(new IndustryActivityRepository(blContext, daContext));
      r.Add(new LanguagesRepository(blContext, daContext));
      r.Add(new CountryRepository(blContext, daContext));
      r.Add(new UsersRepository(blContext, daContext));

      r.Add(new IndustryRepository(blContext, daContext));
      r.Add(new UserTypesRepository(blContext, daContext));

      r.Add(new UserFilesRepository(blContext, daContext));
      r.Add(new DbSettingRepository(blContext, daContext));

      return r;
      }

    protected List<BaseRepository> deleteBaseOrder { get { // RefreshTokens not included - must be processed separately
      return getDeleteBaseOrder(daContext);
      }}

    internal virtual void import(Guid newId, string json, UnloadSetImport unloadSetImport) { throw new NotImplementedException(); }

    protected List<BaseRepository> exportOrder { get { var r=getDeleteBaseOrder(daContext); return r; }}

    protected List<BaseRepository> deleteOrder { get {
      var r=new List<BaseRepository>(){ new RefreshTokenRepository(blContext, daContext) };
      r.AddRange(deleteBaseOrder);
      return r;
      }}

    protected List<BaseRepository> importOrder(DAcontext daContext=null) { var r=getDeleteBaseOrder(daContext); r.Reverse(); return r; }

    internal string snap(string outDirectoryPath=null) {
      var opa=outDirectoryPath;
      if(string.IsNullOrWhiteSpace(opa)){
        var dirname=$"snap-{DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss")}";
        var path = Directory.GetCurrentDirectory(); 
        opa=Path.Combine(path, "Logs",dirname);
        //opa=$"{path}\\Logs\\{dirname}";
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
      var outf=Path.Combine(opa, nam+".txt");
      //var outf=string.Format($"{opa}\\{nam}.txt", opa);
      int k=0;
      using(var os=new StreamWriter(outf, false, System.Text.Encoding.UTF8)){
        foreach(var o in obi){
          var jasons=pack(o); //Newtonsoft.Json.JsonConvert.SerializeObject(o, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
          //TODO possible newline in text
          os.WriteLine(jasons);
          k++;
          }
        os.Close();
        }
      LogInformation($"{nam} snapped {k} records.");
      return k;
      }

    public string iniPath { get {
        var path = Directory.GetCurrentDirectory();
        return Path.Combine(path, "DBinit");
      }}

    internal string reinitialize(string inDirectoryPath=null, bool overwrite=false, bool deleteOld=false, bool generateInits=false, List<string> skip=null) {
      var opa=inDirectoryPath;
      if(opa==null)
        opa=iniPath;

      if (!Directory.Exists(opa))  
        throw new Exception($"Not present import directory '{opa}'");

      int k=0;
      if(deleteOld){
        foreach(var o in deleteOrder)
          k+=o.deleteMe();
        LogInformation($"Total deleted {k} records.");
       } else
        LogInformation("Old data are kept.");

      k=0;
      foreach(var o in importOrder(generateInits?daContext:null))
         k+=o.loadMe(opa, overwrite, deleteOld, generateInits, skip);
      LogInformation($"Total loaded {k} records.");

      return opa;
      }

    protected virtual void adjust(object me){}

    protected virtual int loadMe(string opa, bool overwrite, bool oldDeleted, bool generateInits, List<string> skip) {
      var nam=this.GetType().Name;
      if(skip!=null && skip.Contains(nam))
        return 0;
      var l1=nam.IndexOf("Repository");
      if(l1>0)
        nam=nam.Substring(0, l1);
      var inf=Path.Combine(opa, $"{nam}.txt");
      //var inf=string.Format($"{opa}\\{nam}.txt", opa);
      if(!File.Exists(inf)){
        LogInformation($"{nam} not present.");
        return 0;
        }
      LogInformation($"{nam} loading.");
      if(oldDeleted==false && generateInits==false)
        getOldies();

      int k=0;
      string ln;  
      using(var os=new StreamReader(inf, System.Text.Encoding.UTF8)){
        while ((ln = os.ReadLine()) != null) {  
          //LogInformation(ln);
          if(loadData(ln, overwrite, oldDeleted, generateInits))
            k++; 
          //daContext.SaveChanges();
          }
        if (k>0 && generateInits==false)
          daContext.SaveChanges();
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

    protected virtual bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      throw new NotImplementedException(GetType().Name+".loadData is not implemented");
      }

    protected virtual T getK<T>(object x){
      var r=(T)(x.GetType().GetProperty("Id").GetValue(x, null));
      return r;
      }

    protected virtual Dictionary<T, object> getToldies<T>(){
      var r=getAll4snap().ToDictionary(x=>getK<T>(x));
      return r;
      }

    protected virtual void getOldies() { getOldies<Guid>(); }

    protected object oldiesDictionary;
    protected virtual void getOldies<T>(){
      oldiesDictionary=getToldies<T>();
      }

    public string pack(object o){
      var r=Newtonsoft.Json.JsonConvert.SerializeObject(o, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
      return r;
      }

    protected virtual bool loadDataRow<Te, Tk>(DbSet<Te> set, string json, bool overwrite, bool oldDeleted, bool generateInits) where Te:class {
      var o = Newtonsoft.Json.JsonConvert.DeserializeObject<Te>(json);
      adjust(o);
      if(generateInits){
        daContext.INITaddInit<Te>(o);
        return true;
        }
      object old=null;
      if(oldDeleted==false && oldiesDictionary!=null){
        var k=getK<Tk>(o);
        var d=(Dictionary<Tk, object>)oldiesDictionary;
        if(d.TryGetValue(k, out old)==false)
          old=null;
        }
      if(old==null){
        set.Add(o);
        return true;
        }
      if(overwrite==false)
        return false;
      var v1=pack(old);
      var v2=pack(o);
      if (v1==v2)
        return false;
      return update(old, o);
      }

    protected virtual bool update(object old, object newObject)  {
      throw new NotImplementedException(GetType().Name+".update is not implemented");
      }

    protected virtual void expandInit() {
      throw new NotImplementedException(GetType().Name+".expandInit is not implemented");
      }

    public static void DBinit(BLontext ctx){ new UsersRepository(ctx).reinitialize(null, false, true); }

    public static void ReBase(BLontext ctx){
      DBinit(ctx);
      var o=new UsersRepository(ctx);
      o.expandInit();
      var path = Directory.GetCurrentDirectory();  
      var opa=Path.Combine(path, "ReBase");
      //var opa=$"{path}\\ReBase";
      o.snap(opa);
      }


    internal virtual void initsFromDBinit() {
      reinitialize(iniPath, false, false, true);
      }

    //====================================== initGuids===========================================//
    protected static Dictionary<Guid, bool> _initGuids;

    public Dictionary<Guid, bool> initGuids { get {
      if(_initGuids==null)
        _initGuids=loadInitGuids();
      return _initGuids;
      }}

    private Dictionary<Guid, bool> loadInitGuids() {
      var r=new Dictionary<Guid, bool>();
      foreach(var o in importOrder(daContext))
        o.getGuids(iniPath, r);
      return r;
      }

    protected virtual List<Guid> loadGuids(string opa) {
      var nam=this.GetType().Name;
      var l1=nam.IndexOf("Repository");
      if(l1>0)
        nam=nam.Substring(0, l1);
      var inf=Path.Combine(opa, $"{nam}.txt");
      if(!File.Exists(inf))
        return null;

      var k=new List<Guid>();
      string ln;  
      using(var os=new StreamReader(inf, System.Text.Encoding.UTF8)){
        while ((ln = os.ReadLine()) != null) {
          Guid? t=guid(ln);
          if(t!=null)
            k.Add(t.Value);
          }
        os.Close();  
        }
      return k;
      }

    protected virtual Guid? guid(string json) { return null; }

    protected virtual void getGuids(string iniPath, Dictionary<Guid, bool> r) {
      var t=loadGuids(iniPath);
      if(t==null)
        return;
      foreach(var o in t)
        r[o]=true;
      }

    //===========================================================//
    protected virtual object unloadChildren(object o, UnloadSet us, Dictionary<Guid, bool> skipSet, Dictionary<Guid, bool> unloadedSet){ return null; }
    protected virtual void unloadFollowers(object o, UnloadSet us, Dictionary<Guid, bool> skipSet, Dictionary<Guid, bool> unloadedSet){ }

    protected virtual object byIdU(Guid myId){ return GetType().Name+".unloadMeInternal missing"; }

    protected virtual void unloadMeInternalPlain(object o, Guid id, UnloadSet us, Dictionary<Guid, bool> skipSet, Dictionary<Guid, bool> unloadedSet){
      //if(skipUnload(id, skipSet, unloadedSet))
      //  return;
      unloadedSet[id]=true;
      us.regIt(id, o);
      }

    protected virtual void unloadMeInternal(object o, Guid id, UnloadSet us, Dictionary<Guid, bool> skipSet, Dictionary<Guid, bool> unloadedSet){
      unloadedSet[id]=true;
      var t=unloadChildren(o, us, skipSet, unloadedSet);
      us.regIt(id, o);
      unloadFollowers(t, us, skipSet, unloadedSet);
      }

    protected virtual void unloadMeInternal(Guid id, UnloadSet us, Dictionary<Guid, bool> skipSet, Dictionary<Guid, bool> unloadedSet){
      unloadMeInternal(byIdU(id), id, us, skipSet, unloadedSet);
      }


    protected virtual bool skipUnload(Guid? id, Dictionary<Guid, bool> skipSet, Dictionary<Guid, bool> unloadedSet){
      if(id==null)
        return true;
      var i=id.Value;
      if(skipSet.ContainsKey(i) || unloadedSet.ContainsKey(i))
        return true;
      return false;
      }

    public virtual bool unloadMe(Guid? id, UnloadSet us, Dictionary<Guid, bool> skipSet, Dictionary<Guid, bool> unloadedSet){
      if(skipUnload(id, skipSet, unloadedSet))
        return false;
      unloadMeInternal(id.Value, us, skipSet, unloadedSet);
      return true;
      }

    public virtual bool unloadHim<T>(Guid? id, UnloadSet us, Dictionary<Guid, bool> skipSet, Dictionary<Guid, bool> unloadedSet) where T:BaseRepository, new() {
      if(skipUnload(id, skipSet, unloadedSet))
        return false;
      var rp=new T(){ blContext=blContext, daContext=daContext };
      return rp.unloadMe(id, us, skipSet, unloadedSet);
      }

    public virtual bool unloadMe(List<Guid> ids, UnloadSet us, Dictionary<Guid, bool> skipSet, Dictionary<Guid, bool> unloadedSet) {
      if (ids==null || ids.Count<1)
        return false;
      var idi = ids.Where(x => !skipSet.ContainsKey(x) && !unloadedSet.ContainsKey(x)).Distinct().ToList();
      if (idi.Count<1)
        return false;
      foreach(var i in idi)
        unloadMeInternal(i, us, skipSet, unloadedSet);
      return true;
      }

    protected Guid? upis(Guid? oldis, UnloadSetImport unloadSetImport) {
      if(oldis!=null){
        Guid r=oldis.Value;
        if(unloadSetImport.redirect.TryGetValue(r, out r))
          return r;
        }
      return oldis;
      }

    protected Guid upis(Guid oldis, UnloadSetImport unloadSetImport) {
        Guid r=oldis;
        if(unloadSetImport.redirect.TryGetValue(oldis, out r))
          return r;
      return oldis;
      }
    }
  }
