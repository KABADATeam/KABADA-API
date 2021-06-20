using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace KabadaAPI {
  public class BaseRepository : Blotter, IDisposable   {
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
    }
}
