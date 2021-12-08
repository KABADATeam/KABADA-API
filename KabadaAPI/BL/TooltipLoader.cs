using Kabada;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI {
  public class TooltipLoader : CsvLoader {
    public Dictionary<string, Tooltip> fullSet;
    public bool strict=false;
    protected int usedId=0;

    public List<Tooltip> load(string fileWithFullPath){
      fullSet=new Dictionary<string, Tooltip>();
      loadInternal(fileWithFullPath);
      if(fullSet.Count<1)
        error("No valid lines loaded.");
       if(strict && errors>0)
         return null;
       return fullSet.Values.ToList();
      }

    protected override object storeRow() {
      var o=new Tooltip();
      o.code=yOstring("Code");
      if(string.IsNullOrWhiteSpace(o.code))
        o.code="GeneratedId_"+(++usedId).ToString();
      o.tooltip=yMstring("Tooltip");
      if(strict)
        fullSet.Add(o.code, o);
       else
        fullSet[o.code]=o;
      return null;
      }
    }
  }
