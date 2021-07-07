using System;
using System.Collections.Generic;

namespace Kabada {
  public partial class CostCategory {    
    public Guid category_id;
    public string category_title;
    public string description;
    public List<CostType> types;
    }
  }
