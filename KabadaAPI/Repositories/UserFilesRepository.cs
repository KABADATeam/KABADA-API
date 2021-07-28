using System.Linq;

namespace KabadaAPI {
  public class UserFilesRepository : BaseRepository {
        public UserFilesRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    protected override object[] getAll4snap() { return daContext.UserFiles.ToArray(); }
    protected override string myTable => "UserFiles";

    protected override void loadData(string json) {
      var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.UserFile>(json);
      daContext.UserFiles.Add(o);
      }
    }
  }
