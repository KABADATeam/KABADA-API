using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KabadaAPI {
  public class JobRepository : BaseRepository {
    public JobRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}
    protected override object[] getAll4snap() { return daContext.Jobs.ToArray(); }
    protected override string myTable => "Jobs";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.Job, Guid>(daContext.Jobs, json, overwrite, oldDeleted, generateInits);
      }

    public enum JobKind { invitePlanMember=1 }

    private DbSet<Job> q0 { get { return daContext.Jobs; }}

    public Job create(Job me){
      if(me.Id.ToString()==new Guid().ToString())
        me.Id=Guid.NewGuid();
      me.CreatedAt=DateTime.Now;
      q0.Add(me);
      daContext.SaveChanges();
      return me;
      }
    }
  }
