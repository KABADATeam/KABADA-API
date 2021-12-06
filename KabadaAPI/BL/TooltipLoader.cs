using Kabada;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI {
  public class TooltipLoader : CsvLoader {
    public Dictionary<long, Tooltip> fullSet;

    public List<Tooltip> load(string fileWithFullPath){
      fullSet=new Dictionary<long, Tooltip>();
      loadInternal(fileWithFullPath);
      if(fullSet.Count<1)
        error("No valid lines loaded.");
       return fullSet.Values.ToList();
      }

    protected override object storeRow() {
      var o=new Tooltip();
      o.code=yMlong("Code");
      o.tooltip=yMstring("Tooltip");
      fullSet[o.code]=o;
      return null;
      }
    }
  }
