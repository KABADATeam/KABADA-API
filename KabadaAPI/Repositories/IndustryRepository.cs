using System.Linq;

namespace KabadaAPI {
  public class IndustryRepository : BaseRepository {
     public IndustryRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

     protected override object[] getAll4snap() { return daContext.Industries.ToArray(); }
    }
  }
