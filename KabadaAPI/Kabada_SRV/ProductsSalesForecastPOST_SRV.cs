using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KabadaAPI.Plan_AttributeRepository;

namespace Kabada {
  partial class ProductsSalesForecastPOST {

    internal void perform(BLontext context) {
      var paRepo=new Plan_AttributeRepository(context);
      var idi=products.Select(x=>x.product_id).ToList();
      var prodi=paRepo.byIds(idi);
      if(prodi.Count<products.Count)
        throw new Exception("some products were not found...");
      var kindi=prodi.Select(x=>x.Kind).Distinct().ToList();
      if(kindi.Count>1 || kindi[0]!=(short)PlanAttributeKind.product)
        throw new Exception("not all are Products...");
      idi=prodi.Select(x=>x.BusinessPlanId).Distinct().ToList();
      if(idi.Count>1)
        throw new Exception("MUST belong to one plan...");
      //new BusinessPlansRepository(context, paRepo.daContext).GetPlanForUpdate(context.userGuid, idi[0]); // to validate write rights
      new BusinessPlansRepository(context, paRepo.daContext).validateRW(context.userGuid, idi[0]);
      var pd=prodi.Select(x=>new ProductBL(x, true)).ToDictionary(x=>x.id);
      foreach(var x in products){
        var pn=pd[x.product_id];
        var t=pn.e.salesForcast;
        if(t==null){
          t=new ProductSalesForecastElement();
          pn.e.salesForcast=t;
          }
        t.export=x.export;
        t.sales_forecast_eu=x.sales_forecast_eu;
        t.sales_forecast_non_eu=x.sales_forecast_non_eu;
        t.when_ready=x.when_ready;
        pn.unload();
        }
      paRepo.daContext.SaveChanges();
      }
    }
  }
