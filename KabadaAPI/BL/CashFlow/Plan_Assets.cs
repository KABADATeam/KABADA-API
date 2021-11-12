using Kabada;
using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.MonthedCatalogRow;

namespace KabadaAPI {
  public class Plan_Assets {
    public class SelectorForKeyResources {
      public CatalogRowKind elementKind;
      public string title;
      public Guid category;
      public List<string> types;
      public List<string> ownership;
      public SelectorForKeyResources(CatalogRowKind elementKind, string title, Guid category, List<string> ownership) {
        this.elementKind=elementKind; this.title=title; this.category=category; this.ownership=ownership;
        }
      }
    protected static List<string> BO=new List<string>{ "Buy", "Own"};
    protected static List<string> B=new List<string>{ "Buy" };

    protected static List<SelectorForKeyResources> todo=new List<SelectorForKeyResources>(){
         new SelectorForKeyResources(CatalogRowKind.buildingsElement, "Buildings/ Property", KeyResourceBL.PID, BO) { types=new List<string>{ "Buildings" }}
       , new SelectorForKeyResources(CatalogRowKind.equipElement, "Equipment, Transport & other", KeyResourceBL.PID, BO) {types=new List<string>{ "Equipment", "Transport", "Other" }}
       , new SelectorForKeyResources(CatalogRowKind.inteliaElement, "Intellectual assets (brands, licenses, software & other)", KeyResourceBL.IID, B)
       };

    //===================MASTER===============================//
    protected MonthedCatalog _mc;
    protected BusinessPlanBL _bp;

    protected Plan_Assets dad;
    protected List<Plan_Assets> slaves;

    private MonthedCatalog mc { get { return _mc==null?dad._mc:_mc; }}
    private BusinessPlanBL bp { get { return _bp==null?dad._bp:_bp; }}

    public Plan_Assets(MonthedCatalog catalog, BusinessPlanBL businessPlan) {
      _mc=catalog; _bp=businessPlan;
      slaves=new List<Plan_Assets>();
      }

    public List<int> mcRows { get; protected set; }

    internal void generateRecords(List<KeyResourceBL> pi, List<KabadaAPIdao.Texter> texters) {
      var gsi=pi.Where(x=>x.e.amount>0m).GroupBy(x=>x.texterId).ToDictionary(g => g.Key, g => g.ToList());
      var td=texters.ToDictionary(x=>x.Id);

      foreach(var p in todo){
        var o=new Plan_Assets(this, p);
        slaves.Add(o);
        o.generateRecords(gsi, td);
        }
      //GenerateSumRecords();
      }

    internal decimal investments() {
      var r=0m;
      foreach(var o in slaves){
        if(o.mcSum==0)
          continue;
        r+=NZ.Z(mc.get(o.mcSum).data.get(0));
        }
      return r;
      }

    internal decimal vat() {
      var r=0m;
      foreach(var p in slaves){
        if(p.mcVat!=0)
          r=NZ.Zp(r, mc.get(p.mcVat).data[0]);
        }
      return r;
      }

    public decimal fullSum(){
      var r=slaves.Select(x=>x.extSum).Sum();
      return r;
      }

    //===================SLAVE===============================//
    protected SelectorForKeyResources p;
    public int mcSum;
    public int mcVat;
    public decimal extSum;

    public Plan_Assets(Plan_Assets master, SelectorForKeyResources product) { dad=master; this.p=product; }

    private void generateRecords(Dictionary<Guid, List<KeyResourceBL>> gsi, Dictionary<Guid, Texter> td) {
      var diff=(p.ownership!=B);
      generateRecordsI(gsi, td, diff?null:B); // generate extended
      extSum=NZ.Z(mc.get(mcSum).data.get(0));

      if(diff)
        generateRecordsI(gsi, td, B);
      }

    private void generateRecordsI(Dictionary<Guid, List<KeyResourceBL>> gsi, Dictionary<Guid, Texter> td, List<string> overrideOwnership=null) {
      var isExtended=(overrideOwnership==null);
      var q=td.Values.Where(x=>x.MasterId==p.category);
      if(p.types!=null)
        q=q.Where(x=>p.types.Contains(x.Value.Trim()));
       var w=q.Select(x=>x.Id).ToList();
        if(w.Count<1)
          throw new Exception("kur tad ir?...");
      var us=new List<KeyResourceBL>();
      List<KeyResourceBL> me=null;
      foreach(var t in w)
        if(gsi.TryGetValue(t, out me))
          us.AddRange(me);
      var k=us.Count;
      var ow=overrideOwnership;
      var k0=p.elementKind;
      if(isExtended){
        ow=p.ownership;
        k0=(CatalogRowKind)(3+(int)k0);
        }
      us=us.Where(x=>eligible(ow, x.e.selections)).ToList();
      k=us.Count;

      var su=0m;
      var va=0m;
      foreach(var o in us){
        var pure=NZ.r(o.e.amount.Value/(1m+NZ.Z(o.e.vat)/100m));
        var vaa=o.e.amount.Value-pure;
        var t=mc.add(k0, p.title+":"+td[o.texterId].Value+"."+o.e.name, new MonthedDataRow(new decimal?[]{ pure, vaa, o.e.amount, o.e.vat }));
        t.master=o.id.ToString();
        su+=pure; va+=vaa;
        }
      var kn=(CatalogRowKind)(1+(int)k0);
      mcSum=mc.add(kn, p.title, new MonthedDataRow(su)).id;
      kn=(CatalogRowKind)(1+(int)kn);
      mcVat=mc.add(kn, p.title, new MonthedDataRow(va)).id;
      }

    private bool eligible(List<string> ownership, List<ResourceSelectionBL> selections) {
      var osis=selections.Where(x=>x.title=="Ownership type").FirstOrDefault();
      if(osis==null)
        return false;
      var t=osis.options[osis.selected];
      var r=ownership.Contains(t);
      //if(r==false)
      //  return false;
      return r;
      }

    internal List<CashFlowRow> getRows() {
      var r=new List<CashFlowRow>();
      foreach(var o in slaves){
        if(o.mcSum==0)
          continue;
        r.Add(mc.expose(o.mcSum, 0));
        }
      return r;
      }
    }
  }
