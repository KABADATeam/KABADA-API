using System.Collections.Generic;

namespace KabadaAPI {
  public class IndustryRisksLoader : CsvLoader {
    List<IndustryRiskElementBL> r;

    protected override object storeRow() {
      var r=new IndustryRiskElementBL();
      r.category=yMstring("Risk Category");
      r.type=yMstring("Risk Type");
      r.likelihood=yObyte("Likelihood");
      r.severity=yObyte("Severity");
      r.comments=yOstring("Comments");
      r.countryDeviationScore=yOint("Possible country-specific deviations (Score)");
      r.countryDeviationComment=yOstring("Possible country-specific deviations (Comment))");
      return r;
      }

    public List<IndustryRiskElementBL> load(string fileWithFullPath){
      r=new List<IndustryRiskElementBL>();
      loadInternal(fileWithFullPath);
      if(r.Count<1)
        error("No valid lines loaded.");
      if(errors>0)
        return null;
      return r;
      }
    }
  }
