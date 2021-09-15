using System.Collections.Generic;

namespace Kabada {
  public class ProductSalesForecastElement {
    public int  when_ready;
    public bool export;
    public List<ProductSalesForecastElementMonth> sales_forecast_eu;
    public List<ProductSalesForecastElementMonth> sales_forecast_non_eu;
    }
  }
