using Kabada;
using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KabadaAPI.MonthedCatalogRow;

namespace KabadaAPI {
  public class Plan_Cost {
    //===================MASTER===============================//
    protected MonthedCatalog _mc;
    protected BusinessPlanBL _bp;

    protected Plan_Cost dad;
    protected List<Plan_Cost> slaves;

    private MonthedCatalog mc { get { return _mc==null?dad._mc:_mc; }}
    private BusinessPlanBL bp { get { return _bp==null?dad._bp:_bp; }}

    public Plan_Cost(MonthedCatalog catalog, BusinessPlanBL businessPlan) {
      _mc=catalog; _bp=businessPlan;
      slaves=new List<Plan_Cost>();
      }

    internal void generateRecords(string titel, List<CostBL> myCosts, Guid? salaryID=null) {
      if(myCosts.Count<1)
        return;
      foreach(var o in myCosts)
        o.fillMyCashFlow(bp.e.startup.period); // basic cash flow
      var us=myCosts.Where(x=>x.myCashFlow!=null).ToList();
      if(us.Count<1)
        return;
      // summ by groups
      var idi = us.Select(x => x.texterId).Distinct().ToList();    // type texter Ids used in CostBL
      var ti = bp.textSupport.get(idi).ToDictionary(x => x.Id, x => x.MasterId);  // types   
      var midi = ti.Where(x => x.Value!=null && x.Value!=KeyResourceBL.HID).Select(x => (Guid)x.Value).Distinct().ToList();
      var mi=bp.textSupport.get(midi).OrderBy(x=>x.Value).ToList();
      var gsi=us.GroupBy(x=>ti[x.texterId]).ToDictionary(g => g.Key, g => g.ToList());
      
      //var val=mVal(titel, bp.o.Id);mcVal=val.id;
      //var vat=mVat(titel, bp.o.Id);mcVat=vat.id;
      foreach(var o in mi){
        var p=new Plan_Cost(this, o);
        slaves.Add(p);
        p.generateRecordsI(gsi[o.Id], salaryID);
        //for(var m=0; m<bp.pPeriod; m++){
        //  val.data[m]=NZ.Np(val.data[m], mc.get(p.mcVal).data[m]);
        //  vat.data[m]=NZ.Np(vat.data[m], mc.get(p.mcVat).data[m]);
        //  }

        if(o.Id==salaryID) { // || o.Value=="Salaries"){
          if(specialRow!=0)
            throw new Exception("Special rows already present...");
          p.mcVat=0;
          var td=new List<decimal?>(){ null };
          td.AddRange(mc.get(p.mcVal).data);
          var sr=mc.add(CatalogRowKind.salaryTax, "Labor taxes (katrai valstij savs %)", new MonthedDataRow(td)); specialRow=sr.id;
          var st=bp.salaryTax;
          for(int m=0; m<sr.data.Count; m++){
            sr.data[m]=NZ.Nr(NZ.Z(sr.data[m])*st);
            //var w=NZ.Np(val.data[m], sr.data[m]);
            //if(m<val.data.Count)
            //  val.data[m]=w;
            // else
            //  val.data.Add(w);
            }
          var so=new Plan_Cost(mc, bp);
          slaves.Add(so); so.mcVal=specialRow;
          }
        }
      mcVal=mc.plus(CatalogRowKind.costValue, titel, slaves.Select(x=>x.mcVal).ToArray()).id;
      mcVat=mc.plus(CatalogRowKind.costVat, titel, slaves.Select(x=>x.mcVat).ToArray()).id;
      }

    protected MonthedCatalogRow mCR(CatalogRowKind kind, string titel, Guid? master=null){
      var val=mc.add(kind, titel);
      //mcVal=val.id;
      if(master!=null)
        val.master=master.ToString();
      val.data=new MonthedDataRow(bp.pPeriod+1);
      return val;
      }

    protected MonthedCatalogRow mVal(string titel, Guid? master){ return mCR(CatalogRowKind.costValue, titel, master); }
    protected MonthedCatalogRow mVat(string titel, Guid? master){ return mCR(CatalogRowKind.costVat, titel, master); }

    internal CashFlowTable table(string titelnull) {
      var r=new CashFlowTable(){ title=titelnull };
      r.rows=rows();
      return r;
      }

    internal List<CashFlowRow> rows() {
      var r=new List<CashFlowRow>();
      foreach(var o in slaves)
        r.Add(mc.expose(o.mcVal, bp.pPeriod));
      return r;
      }

   //===================SLAVE===============================//
    private Texter p; // group
    public int mcVal;
    public int mcVat;
    protected int specialRow;

    public Plan_Cost(Plan_Cost master, KabadaAPIdao.Texter tx) { dad=master; this.p=tx; }

    private void generateRecordsI(List<CostBL> li, Guid? salaryID) {
      var n=bp.pPeriod;
      var val=mVal(p.Value, p.Id);mcVal=val.id;
      var vat=mVat(p.Value, p.Id);mcVat=vat.id;
      foreach(var o in li){
        var v=mVal(o.e.name, o.id); v.data=new MonthedDataRow(o.myCashFlow.monthlyValue);
        var t=mVat(o.e.name, o.id); t.data=new MonthedDataRow();
        var mu=NZ.Z(o.e.vat)/100m;
        for(short m=0; m<=n; m++){
          var vl=mu*NZ.Z(v.data.get(m));
          t.data.Add(NZ.N(vl));
          val.data[m]=NZ.Np(val.data[m], v.data.get(m));
          vat.data[m]=NZ.Np(vat.data[m], vl);
          }
        }
      }
    }
    }
