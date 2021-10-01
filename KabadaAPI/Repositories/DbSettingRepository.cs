using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KabadaAPI {
  public class DbSettingRepository : BaseRepository {
    public DbSettingRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    private DbSet<DbSetting> q0 { get { return daContext.DbSettings; }}    

    internal DbSetting byId(EnumDbSettings id) {
      var k=id.ToString();
      var r=q0.Where(x=>x.Id==k).FirstOrDefault();
      return r;
      }

    protected override object[] getAll4snap() { return daContext.DbSettings.ToArray(); }
    protected override string myTable => "DbSettings";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.DbSetting, string>(daContext.DbSettings, json, overwrite, oldDeleted, generateInits);
      }

    protected override void getOldies() { getOldies<string>(); }

    public enum EnumDbSettings { initialDataSetLevel }

    internal void add(EnumDbSettings id, string v) {
      var o=new DbSetting(){ Id=id.ToString(), Value=v };
      daContext.DbSettings.Add(o);
      daContext.SaveChanges();
      }
    }
  }
