using System.Linq;

namespace KabadaAPI {
  public class RefreshTokenRepository : BaseRepository {
        public RefreshTokenRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    //   protected override object[] getAll4snap() { return daContext.RefreshTokens.ToArray(); }
    protected override string myTable => "RefreshTokens";
    }
  }
