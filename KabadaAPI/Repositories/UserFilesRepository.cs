using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KabadaAPI {
  public class UserFilesRepository : BaseRepository {
        public UserFilesRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    protected override object[] getAll4snap() { return daContext.UserFiles.ToArray(); }
    protected override string myTable => "UserFiles";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.UserFile, Guid>(daContext.UserFiles, json, overwrite, oldDeleted, generateInits);
      }

    //protected override bool loadData(string json, bool overwrite) {
    //  var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.UserFile>(json);
    //  daContext.UserFiles.Add(o);
    //  return true;
    //  }

    protected override Guid? guid(string json) {
      var o = Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.UserFile>(json);
      return o.Id;
      }

    private DbSet<UserFile> q0 { get { return daContext.UserFiles; }}

    public UserFile byId(Guid id){ return q0.Where(x=>x.Id==id).FirstOrDefault(); }
    }
  }
