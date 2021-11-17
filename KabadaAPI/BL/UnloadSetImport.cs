using Kabada;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class UnloadSetImport {
    public Guid? targetOwner;
    public string targetNamePattern;
    public Dictionary<Guid, Guid> redirect;
    public BusinessPlansRepository bR;

    public UnloadSetImport() { redirect=new Dictionary<Guid, Guid>(); targetNamePattern="Imported:{0}"; }

    Dictionary<string, BaseRepository> repos;

    internal void import(UnloadSet r) {
      foreach(var e in r.elements)
        redirect.Add(e.id, Guid.NewGuid());
      repos=new Dictionary<string, BaseRepository>(){{"BusinessPlan", bR}};
      foreach(var e in r.elements)
        import(e);
      bR.daContext.SaveChanges();
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
