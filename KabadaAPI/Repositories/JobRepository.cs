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
    }
  }
