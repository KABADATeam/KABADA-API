namespace Kabada {
  public class ProductSalesForecastElement {
    public int  when_ready;
    public bool export;
    public string sales_forecast_eu; // "json string", // string format [ { month: "integer", price: "decimal", qty: "integer" , vat: "decimal", paid: "string" }, ...,  { ... } ]
    public string sales_forecast_non_eu; // "json string" // string format [ { month: "integer", price: "decimal", qty: "integer" , vat: "decimal", paid: "string" }, ...,  { ... } ]    }
    }
  }
