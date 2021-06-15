using Microsoft.EntityFrameworkCore.Storage;

namespace KabadaAPI {
  public class Transactioner : BaseRepository {
    protected IDbContextTransaction trans;

    public DAcontext Context { get { return context; }}

    public Transactioner(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger =null) : base(configuration, logger) {
      trans=context.Database.BeginTransaction();
      }

    public void Rollback(){
      if(trans!=null){
        trans.Rollback();
        trans=null;
        }
      }

    public void Commit(){
      trans.Commit();
      trans=null;
      }

    protected override void dispose() {
      Rollback();
      base.dispose();
      }
    }
  }
