using Kabada;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class UnloadSetImport {
    public const string BPN="BusinessPlan";

    public Guid? targetOwner;
    public string targetNamePattern;
    public Dictionary<Guid, Guid> redirect;
    public BusinessPlansRepository bR;

    public UnloadSetImport() { redirect=new Dictionary<Guid, Guid>(); targetNamePattern="Imported:{0}"; }

    Dictionary<string, BaseRepository> repos;

    internal Guid import(UnloadSet r) {
      Guid ret=default(Guid);
      foreach(var e in r.elements){
        var t=Guid.NewGuid();
        redirect.Add(e.id, t);
        if(e.type==BPN)
          ret=t;
        }
      repos=new Dictionary<string, BaseRepository>(){{BPN, bR}};
      foreach(var e in r.elements)
        import(e);
      bR.daContext.SaveChanges();
      return ret;
      }

    private void import(UnloadSetElement e) {
      BaseRepository repo=null;
      if(repos.TryGetValue(e.type, out repo)==false){
        var rn="KabadaAPI."+e.type+"Repository";
        var t=Type.GetType(rn);
        if(t==null){
          rn="KabadaAPI."+e.type+"sRepository";
          t=Type.GetType(rn);
          }
        var wr=Activator.CreateInstance(t);
        repo=(BaseRepository)wr;
        repos.Add(e.type, repo);
        repo.blContext=bR.blContext; repo.daContext=bR.daContext;
        }
      repo.import(redirect[e.id], e.contents, this);
      }
    }
  }
