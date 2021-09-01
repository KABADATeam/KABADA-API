using System;
using System.Collections.Generic;

namespace Kabada {
  public class CategorizedCosts {
    public string category_title;   
    public Guid category_id;
    public List<TypedCost> types;
    }
  }