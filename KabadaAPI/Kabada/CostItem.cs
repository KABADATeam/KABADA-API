using System;
using System.Collections.Generic;

namespace Kabada {
  public class CostItem {
    public Guid cost_item_id;
    public decimal? price;
    public decimal? vat;
    public short first_expenses;
    public List<decimal?> monthly_expenses;
    }
  }