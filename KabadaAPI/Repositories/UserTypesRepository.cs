using System.Linq;

namespace KabadaAPI {
  public class UserTypesRepository : BaseRepository {
    public UserTypesRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    protected override object[] getAll4snap() { return daContext.UserTypes.ToArray(); }
    protected override string myTable => "UserTypes";

    //protected override void loadData(string json) {
    //  var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.UserType>(json);
    //  daContext.UserTypes.Add(o);
    //  }
    }
  }
