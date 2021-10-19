using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class Assets_POST {
    internal void perform(BLontext ctx) {
      var plan=new BusinessPlansRepository(ctx).GetPlanForUpdate(ctx.userGuid, business_plan_id); // only to validate rights on plan
        var paRepo=new Plan_AttributeRepository(ctx);
        var kri=paRepo.getResources(business_plan_id).ToDictionary(x=>x.Id);
        fill(kri, physical_assets);
        paRepo.daContext.SaveChanges();
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
