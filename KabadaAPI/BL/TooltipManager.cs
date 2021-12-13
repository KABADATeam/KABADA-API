using Kabada;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace KabadaAPI {
  public class TooltipManager : LoaderManager {
    public TooltipManager(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) { filePattern="Tooltips.csv"; }
    public TooltipManager(IConfiguration configuration, ILogger<BackgroundJobber> logger, DAcontext dContext=null) : this(new BLontext(configuration, logger), dContext) {}

    protected string bfile(){ return Path.Combine(new BusinessPlansRepository(blContext).iniPath, filePattern); }

    internal List<Tooltip> load(bool strict) {
      var l=new TooltipLoader(){ infoReporter=log, errorReporter=err, strict=strict};
      //var f=Path.Combine(new BusinessPlansRepository(blContext).iniPath, filePattern);
      return l.load(bfile());
      }

    protected override void performSingleInternal(string f, string basic, DateTime start) {
      if(new TooltipLoader(){ infoReporter=log, errorReporter=err, strict=true}.load(f)==null)
        throw new Exception("CSV load failed.");
      var targa=bfile(); //Path.Combine(initDirectory, filePattern);
      File.Copy(f, targa, true);
      }
    }
  }
