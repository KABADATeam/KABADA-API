using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace KabadaAPI {
  public class VatManager : LoaderManager {
    public VatManager(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {
      filePattern="*VAT.csv";
      }

    public VatManager(IConfiguration configuration, ILogger<BackgroundJobber> logger, DAcontext dContext=null) : this(new BLontext(configuration, logger), dContext) {}

    protected override void performSingleInternal(string f, string basic, DateTime start) {
      if(new VatLoader(){ infoReporter=log, errorReporter=err}.load(f, blContext)==false)
        throw new Exception("CSV load failed.");
      }
    }
  }
