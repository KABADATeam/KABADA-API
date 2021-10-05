using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.MonthedCatalogRow;

namespace KabadaAPI {
  public class Production {
    protected ProductBL p;
    public int mcIncomePure;
    public int mcVat;

    public Production(ProductBL p) { this.p=p; }

    internal void generateRecords(MonthedCatalog mc, BusinessPlanBL bp) {
      var tit=p.e.title;

      var income=mc.add(CatalogRowKind.productSelledPure, tit, new MonthedDataRow()); mcIncomePure=income.id; income.master=p.id.ToString();
      var vat=mc.add(CatalogRowKind.productVat, tit, new MonthedDataRow()); mcVat=vat.id; vat.master=p.id.ToString();

      // month 0
      income.data.Add(null); vat.data.Add(null);

      for(var m=1; m<=bp.pPeriod; m++){
        var eu=p.eu(m);
        decimal? euS=(eu==null)?null:(eu.qty * eu.price);
        income.data.Add(NZ.Np(euS, p.noneuSale(m)));
        decimal? w=null;
        if(bp.e.startup.vat_payer==true && euS!=null){
          w=NZ.N(euS.Value*eu.vat/100);
          }
        vat.data.Add(w);
        }
      }

    public static int[] GenerateSumRecords(MonthedCatalog mc, List<Production> productions, BusinessPlanBL bp){
      var r=new int[2]{ 0, 0 };
      var s=mc.add(CatalogRowKind.productSelledPureSum, "TOTAL revenue from core business", new MonthedDataRow());
      r[0]=s.id;
      var db=productions.Select(x=>mc.get(x.mcIncomePure).data).ToList();
      for(var m=0; m<=bp.pPeriod; m++)
        s.data.Add(NZ.Np(db.Select(x=>x.get(m))));

      var v=mc.add(CatalogRowKind.productSelledPureSum, "VAT received(in EU)", new MonthedDataRow());
      r[0]=v.id;
      db=productions.Select(x=>mc.get(x.mcVat).data).ToList();
      for(var m=0; m<=bp.pPeriod; m++)
        v.data.Add(NZ.Np(db.Select(x=>x.get(m))));
      return r;
      }
    }
  }
