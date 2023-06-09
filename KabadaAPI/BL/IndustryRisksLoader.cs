﻿using Kabada;
using System.Collections.Generic;

namespace KabadaAPI {
  public class IndustryRisksLoader : CsvLoader {
    List<IndustryRisk> returnList;

    protected override object storeRow() {
      var r=new IndustryRisk();
      r.category=yMstring("Risk Category");
      r.type=yMstring("Risk Type");
      r.likelihood=yMbyte("Likelihood");
      r.severity=yMbyte("Severity");
      r.comments=yOstring("Comments");
      r.countryDeviationScore=yOint("Possible country-specific deviations (Score)");
      r.countryDeviationComment=yOstring("Possible country-specific deviations (Comment))");

      r.validate();
      returnList.Add(r);
      return r;
      }

    public List<IndustryRisk> load(string fileWithFullPath){
      returnList=new List<IndustryRisk>();
      loadInternal(fileWithFullPath);
      if(returnList.Count<1)
        error("No valid lines loaded.");
      if(errors>0)
        return null;
      return returnList;
      }
    }
  }
