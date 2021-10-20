using KabadaAPI;
using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class Assets {
    internal void read(BLontext ctx, Guid planId) {
      var pl=new BusinessPlanBL(new BusinessPlansRepository(ctx).GetPlan(planId, ctx.userGuid));
      is_assets_completed=pl.o.IsAssetsCompleted;
      var atri= new Plan_AttributeRepository(ctx).getResources(planId).Select(x=>new KeyResourceBL(x)).ToList();
      if(atri.Count<1)
        return;
      var tRepo=new TexterRepository(ctx);
//      var typi=tRepo.getKeyResourceTypes(KeyResourceBL.HID).Where(x=>x.MasterId!=null).ToDictionary(x=>x.Id, x=>false);
      var w=tRepo.getKeyResourceTypes(null).ToDictionary(x=>x.Id);     
      physical_assets=make(atri, w);
      total_investments=pl.e.startup.total_investments;
      own_assets=pl.e.startup.own_assets;
      investment_amount=pl.e.startup.investment_amount;
      }

    protected List<AssetElement> make(List<KeyResourceBL> source, Dictionary<Guid, Texter> types){
      if(source==null || source.Count<1)
        return null;
      return source.Select(x=>new AssetElement {
               amount=x.e.amount, resource_id=x.id, vat=x.e.vat, resource_title=x.e.name, resource_status=slurp(x.e.selections), type_title=types[x.texterId].Value
             }).ToList();
      }

    private string slurp(List<ResourceSelectionBL> selections) {
      if(selections==null)
        return null;
      var plus=selections.Where(x=>x.title==KeyResourceBL.OwnershipType).FirstOrDefault();
      if(plus==null)
        return null;
      if(plus.options==null || plus.options.Count<1)
        return null;
      return plus.options[plus.selected];
      }
    }
  }
