using Microsoft.EntityFrameworkCore.Storage;

namespace KabadaAPI {
  public class Transactioner : BaseRepository {
    protected IDbContextTransaction trans;

    public DAcontext Context { get { return daContext; }}

    public Transactioner(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {
      trans=daContext.Database.BeginTransaction();
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
