using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public abstract class BAseAttributeBL {
    protected object _o;   // table object containing full information
    protected object _e;   // expanded element (must be extracted/packed to the _o

    public virtual Guid id { get; protected set; }
    public virtual short kind { get; protected set; }
    public virtual short orderValue { get; set; }
    protected virtual string attrVal { get; set; }

    public virtual string packedE { get { return JsonConvert.SerializeObject(_e, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); }}      
    protected virtual void assignE<T>(string packed){ _e=JsonConvert.DeserializeObject<T>(packed); }

    protected virtual void packE(){ attrVal=packedE; }
    protected virtual T unloadMe<T>(bool skipPack=false){
      if(!skipPack)
        packE();
      return (T)_o;
      }

    protected virtual void validateKind(short kindForCheck){ 
      if(kind!=kindForCheck)
        throw new Exception($"Expected read kind={kind} does not meat the expectedKind={kindForCheck}");
      }
    protected virtual void validateKind(List<short> kindsForCheck){
      if(!kindsForCheck.Contains(kind))
        throw new Exception($"Expected read kind={kind} does not meat the expectedKind={kindsForCheck.ToString()}");
      }
    }
  }
