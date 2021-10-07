using Kabada;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.MonthedCatalogRow;

namespace KabadaAPI {
  public class Plan_SaleForecast {
    //===================MASTER===============================//
    protected MonthedCatalog _mc;
    protected BusinessPlanBL _bp;

    protected Plan_SaleForecast dad;
    protected List<Plan_SaleForecast> slaves;

    private MonthedCatalog mc { get { return _mc==null?dad._mc:_mc; }}
    private BusinessPlanBL bp { get { return _bp==null?dad._bp:_bp; }}

    public Plan_SaleForecast(MonthedCatalog catalog, BusinessPlanBL businessPlan) {
      _mc=catalog; _bp=businessPlan;
      slaves=new List<Plan_SaleForecast>();
      }

    protected int summRow;
    protected int vatRow;

    internal void generateRecords(List<ProductBL> pi) {
      foreach(var p in pi){
        var o=new Plan_SaleForecast(this,p);
        slaves.Add(o);
        o.generateRecords();
        }
      GenerateSumRecords();
      }

    public void GenerateSumRecords(){
      var s=_mc.add(CatalogRowKind.productSelledPureSum, "TOTAL revenue from core business", new MonthedDataRow());
      summRow=s.id;
      var db=slaves.Select(x=>_mc.get(x.mcIncomePure).data).ToList();
      for(var m=0; m<=_bp.pPeriod; m++)
        s.data.Add(NZ.Np(db.Select(x=>x.get(m))));

      var v=_mc.add(CatalogRowKind.productVatSum, "VAT received(in EU)", new MonthedDataRow());
      vatRow=v.id;
      db=slaves.Select(x=>_mc.get(x.mcVat).data).ToList();
      v.data.Add(null); // shift one month
      for(var m=0; m<=_bp.pPeriod; m++)
        v.data.Add(NZ.Np(db.Select(x=>x.get(m))));
      }

    internal List<CashFlowRow> basicRows() {
      var r=new List<CashFlowRow>();
      foreach(var s in slaves)
        r.Add(_mc.expose(s.mcIncomePure, _bp.pPeriod));
      return r;
      }

    internal List<CashFlowRow> summaries() {
      var r=new List<CashFlowRow>();
      r.Add(_mc.expose(summRow, _bp.pPeriod));
      r.Add(_mc.expose(vatRow, _bp.pPeriod));
      return r;
      }

    //===================SLAVE===============================//
    protected ProductBL p;
    public int mcIncomePure;
    public int mcVat;

    public Plan_SaleForecast(Plan_SaleForecast master, ProductBL product) { dad=master; this.p=product; }

    internal void generateRecords() {
      var tit=p.e.title;

      var income=mc.add(CatalogRowKind.productSelledPure, tit, new MonthedDataRow(bp.pPeriod+4)); mcIncomePure=income.id; income.master=p.id.ToString();
      var vat=mc.add(CatalogRowKind.productVat, tit, new MonthedDataRow(bp.pPeriod+4)); mcVat=vat.id; vat.master=p.id.ToString();

      for(var m=1; m<=bp.pPeriod; m++){
        var e=p.eu(m);
        if(e!=null){
          var euS=e.qty * e.price;
          if(euS!=0){
            var tm=m+e.payShift();
            income.data[tm]=NZ.Np(income.data[tm], euS);
            if(e.vat!=0)
              vat.data[tm]=NZ.Np(vat.data[tm], euS*e.vat/100);
            }
          }

        e=p.noneu(m);
        if(e!=null){
          var euS=e.qty * e.price;
          if(euS!=0){
            var tm=m+e.payShift();
            income.data[tm]=NZ.Np(income.data[tm], euS);
            }
          }

        }
      }
    }
  }
