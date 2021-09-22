using System;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class ProductBL : BAsePlan_AttributeTypedBL<ProductElementBL> { //Plan_AttributeBL<ProductElementBL> {
    private const short KIND=(short)PlanAttributeKind.product;

    public ProductBL(Guid plan, Guid texter) : base(KIND, plan, texter) {}
    public ProductBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false, Guid? planForValidate=null) : base(old, forUpdate, planForValidate, kindForValidate: KIND){}

    public ProductBL(Guid byId, Plan_AttributeRepository repo, Guid? planForValidate=null) : base(byId, repo, true, planForValidate, KIND) {}

    internal decimal? euSale(int m) {
      if(e.salesForcast==null || e.salesForcast.sales_forecast_eu==null)
        return null;
      var o=e.salesForcast.sales_forecast_eu.Where(x=>x.month==m).FirstOrDefault();
      if(o==null)
        return null;
      return o.price*o.qty;
      }

    internal decimal? noneuSale(int m) {
      if(e.salesForcast==null || e.salesForcast.sales_forecast_non_eu==null)
        return null;
      var o=e.salesForcast.sales_forecast_non_eu.Where(x=>x.month==m).FirstOrDefault();
      if(o==null)
        return null;
      return o.price*o.qty;
      }
    }
  }
