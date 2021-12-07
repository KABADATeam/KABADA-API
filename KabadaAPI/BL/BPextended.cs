using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KabadaAPI {
  public class BPextended : KabadaAPIdao.BusinessPlan {
     public KabadaAPIdao.Language Language { get; set; }
     public KabadaAPIdao.Country Country { get; set; }
     public KabadaAPIdao.User User { get; set; }


    public BPextended(){}
    public BPextended(KabadaAPIdao.BusinessPlan me){ set(me); }
    public BPextended(BPjoin me){ set(me); }

    protected virtual void MDScloneProperty(PropertyInfo targetP, PropertyInfo sourcrP, object sourceO){ targetP.SetValue(this, sourcrP.GetValue(sourceO)); }

    protected virtual List<PropertyInfo> MDSpropertyInfos(Type type, List<string> include=null, List<string> exclude=null){
      var r=type.GetProperties().ToList();
      if(include!=null)
        r=r.Where(x=>include.Contains(x.Name)).ToList();
      if(exclude!=null)
        r=r.Where(x=>!exclude.Contains(x.Name)).ToList();
      return r;
      }

    internal virtual void MDScloneProperties(object sourceO, List<string> include=null, List<string> exclude=null){
      var mt=GetType();
      var todo=MDSpropertyInfos(mt, include, exclude);
      if(todo==null || todo.Count<1)
        return;
      var st=sourceO.GetType();
      if(mt.Equals(st)){
        foreach(var p in todo)
          MDScloneProperty(p, p, sourceO);
        return;
        }
      var sd=MDSpropertyInfos(st).ToDictionary(x=>x.Name);
      PropertyInfo sp=null;
      foreach(var p in todo){
        if(sd.TryGetValue(p.Name, out sp))
          MDScloneProperty(p, sp, sourceO);
        }
      }

    public void set(KabadaAPIdao.BusinessPlan me){  MDScloneProperties(me); }

    public void set(BPjoin joined){
      set(joined.bp);
      Country=joined.cn;
      Activity=joined.ac;
      Language=joined.lng;
      User=joined.us;
      }
    }
  }
