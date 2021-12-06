using Kabada;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI {
  public class TooltipManager : LoaderManager {
    public TooltipManager(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) { }

    internal List<Tooltip> load() {
      var l=new TooltipLoader(){ infoReporter=log, errorReporter=err};
      l.fullSet=new Dictionary<long, Tooltip>();
      var f=Path.Combine(new BusinessPlansRepository(blContext).iniPath, "Tooltips.csv");
      return new TooltipLoader(){ infoReporter=log, errorReporter=err}.load(f);
      }
    }
  }
