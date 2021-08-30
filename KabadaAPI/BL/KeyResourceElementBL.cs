using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class KeyResourceElementBL {
    public Guid type_id;
    public string name;
    public string description;
    public List<ResourceSelectionBL> selections;
    public decimal? amount;
    public decimal? vat;
    }
  }
