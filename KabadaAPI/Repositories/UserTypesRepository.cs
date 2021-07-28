using System.Linq;

namespace KabadaAPI {
  public class UserTypesRepository : BaseRepository {
        public UserTypesRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

     protected override object[] getAll4snap() { return daContext.UserTypes.ToArray(); }
    }
  }
