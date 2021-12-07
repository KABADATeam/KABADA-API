using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public class KeyResourceElementBL {
    public Guid type_id;
    public string name;
    public string description;
    public List<ResourceSelectionBL> selections;
    public decimal? amount;
    public decimal? vat;
    
    public static string selectionValue(List<ResourceSelectionBL> selections, string selectionName=KeyResourceBL.OwnershipType) {
      if(selections==null)
        return null;
      var plus=selections.Where(x=>x.title==selectionName).FirstOrDefault();
      if(plus==null)
        return null;
      if(plus.options==null || plus.options.Count<1)
        return null;
      return plus.options[plus.selected];
      }

    }
  }
