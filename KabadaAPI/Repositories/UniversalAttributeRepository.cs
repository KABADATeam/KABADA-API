using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KabadaAPI {
  public class UniversalAttributeRepository : BaseRepository {
    public UniversalAttributeRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    private DbSet<UniversalAttribute> q0 { get { return daContext.UniversalAttributes; }}

    protected override object[] getAll4snap() { return q0.ToArray(); }
    protected override string myTable => "UniversalAttributes";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.UniversalAttribute, Guid>(q0, json, overwrite, oldDeleted, generateInits);
      }


   }
  }
