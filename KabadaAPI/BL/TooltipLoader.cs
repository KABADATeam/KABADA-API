using Kabada;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI {
  public class TooltipLoader : CsvLoader {
    public Dictionary<string, Tooltip> fullSet;

    public List<Tooltip> load(string fileWithFullPath){
      fullSet=new Dictionary<string, Tooltip>();
      loadInternal(fileWithFullPath);
      if(fullSet.Count<1)
        error("No valid lines loaded.");
       return fullSet.Values.ToList();
      }

    protected override object storeRow() {
      var o=new Tooltip();
      o.code=yMstring("Code");
      o.tooltip=yMstring("Tooltip");
      fullSet[o.code]=o;
      return null;
      }
    }
  }
