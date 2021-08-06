using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI {
  public class DbSettingRepository : BaseRepository {
    public DbSettingRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    protected override object[] getAll4snap() { return daContext.DbSettings.ToArray(); }
    protected override string myTable => "DbSettings";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.DbSetting, Guid>(daContext.DbSettings, json, overwrite, oldDeleted, generateInits);
      }

    public enum EnumDbSettings { initialDataSetLevel }
    }
  }
