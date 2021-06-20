using KabadaAPIdao;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  internal class LanguagesRepository : BaseRepository {
    public LanguagesRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    public List<Language> get() {
      var r = daContext.Languages.OrderBy(x=>x.Code).ToList();
      return r;
      }
    }
  }
