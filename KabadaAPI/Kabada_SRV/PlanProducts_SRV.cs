using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class PlanProducts {
    protected BLontext ctx;

    internal void read(BLontext context, Guid planId) {
      ctx=context;

      this.products=new  List<ProductReport>();

      var pl=new BusinessPlansRepository(ctx).GetPlan(planId);
      this.is_proposition_completed=pl.IsPropositionCompleted;
      
      var atri= new Plan_AttributeRepository(ctx).getProducts(planId);
      if(atri.Count<1)
        return;

      //var tidi=atri.Select(x=>x.TexterId).Distinct().ToList();
      //var typi=new TexterRepository(ctx).get(tidi).ToDictionary(x=>x.Id);
      var productTypes=new TexterRepository(ctx).getProductTypeMeta().ToDictionary(x=>x.Id);
      var priceLevels=new TexterRepository(ctx).getProductPriceLevelMeta().ToDictionary(x=>x.Id);
      var qualityOptions = new TexterRepository(ctx).getProductQualityOptionMeta().ToDictionary(x => x.Id);
      ProductReport o =null;
      ProductAttribute pa=new ProductAttribute();
      foreach(var a in atri){
        o=new ProductReport(); products.Add(o);
        pa.unpack(a.AttrVal);
        o.id=a.Id;
        o.name = pa.title;
        o.product_type=productTypes[pa.product_type].Value;        
        o.price = priceLevels[pa.price_level].Value;
        o.value = qualityOptions[pa.quality_level].Value;
        }
      }
      
      }
  }
