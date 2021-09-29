using System.Collections.Generic;

namespace KabadaAPI {
  public class CostElementBL {
    public string name;
    public string description;
    public decimal? price;
    public decimal? vat;
    public short? first_expenses;
    public List<decimal?> monthly_expenses;
    }
  }