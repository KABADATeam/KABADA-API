using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class PlanSalesForecasts {

    internal void read(BLontext context, Guid planId) {
      var pRepo=new BusinessPlansRepository(context);
      var p=pRepo.GetPlan(planId, context.userGuid);
      is_sales_forecast_completed=p.IsSalesForecastCompleted;

      var prodi=new Plan_AttributeRepository(context, pRepo.daContext).getProducts(planId).Select(x=>new ProductBL(x, true)).ToList();
      products=new List<ProductSalesForecast>();
      foreach(var x in prodi){
        var w=new ProductSalesForecast(){ product_id=x.id };
        products.Add(w);
        if(x.e.salesForcast!=null){
          var t=x.e.salesForcast;
          w.export=t.export;
          w.sales_forecast_eu=t.sales_forecast_eu;
          w.sales_forecast_non_eu=t.sales_forecast_non_eu;
          w.when_ready=t.when_ready;
          }
        }
      }
    }
  }
