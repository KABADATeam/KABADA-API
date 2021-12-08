using Kabada;
using System.Collections.Generic;
using System.IO;

namespace KabadaAPI {
  public class TooltipManager : LoaderManager {
    public TooltipManager(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) { }

    internal List<Tooltip> load(bool strict) {
      var l=new TooltipLoader(){ infoReporter=log, errorReporter=err, strict=strict};
      //l.fullSet=new Dictionary<string, Tooltip>();
      var f=Path.Combine(new BusinessPlansRepository(blContext).iniPath, "Tooltips.csv");
      return l.load(f);
      }
    }
  }
