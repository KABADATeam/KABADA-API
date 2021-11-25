using System;
using System.Collections.Generic;

namespace Kabada {
  public class TypedCost {
    public Guid cost_item_id;
    public string type_title;
    public string type_name;
    public Guid type_id;
    public decimal? price;
    public decimal? vat;
    public short? first_expenses;
    public List<decimal?> monthly_expenses;
    }
  }