using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class Assets_POST {
    internal void perform(BLontext ctx) {
      var bRepo=new BusinessPlansRepository(ctx);
      var plan=bRepo.GetPlanForUpdate(ctx.userGuid, business_plan_id);
      var t=new BusinessPlanBL(plan, true);
      t.e.startup.total_investments=total_investments;
      t.e.startup.own_assets=own_assets;
      t.e.startup.investment_amount=investment_amount;
      t.unload();

      var paRepo=new Plan_AttributeRepository(ctx, bRepo.daContext);
      var kri=paRepo.getResources(business_plan_id).ToDictionary(x=>x.Id);
      fill(kri, physical_assets);

      bRepo.daContext.SaveChanges();
      }

    private void fill(Dictionary<Guid, KabadaAPIdao.Plan_Attribute> kri, List<AssetPosterElement> assets) {
      if(assets==null)
        return;
      foreach(var x in assets){
        var upo=new KeyResourceBL(kri[x.resource_id], true);
        upo.e.vat=x.vat;
        upo.e.amount=x.amount;
        upo.unload();
        }
      }
    }
  }
