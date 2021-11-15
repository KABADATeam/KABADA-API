using KabadaAPI;
using System;

namespace KabadaAPIdao {
  public abstract class DaoBase {
    public virtual object cloned(){ return null; }
    public virtual T clone<T>(){ return (T)cloned(); }
    public virtual BaseRepository myRepository(BLontext context, DAcontext daContext=null) { return null; }
    public virtual Guid myGuid(){ return new Guid(); }
    }
  }
