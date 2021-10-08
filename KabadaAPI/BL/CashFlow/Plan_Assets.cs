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

    protected static List<SelectorForKeyResources> todo=new List<SelectorForKeyResources>(){
         new SelectorForKeyResources(CatalogRowKind.buildingsElement, "Buildings/ Property (bez PVN)", KeyResourceBL.PID, BO) { types=new List<string>{ "Buildings" }}
       , new SelectorForKeyResources(CatalogRowKind.equipElement, "Prod.Machinery and Equipment, Transport & other", KeyResourceBL.PID, BO) {types=new List<string>{ "Equipment", "Transport", "Other" }}
       , new SelectorForKeyResources(CatalogRowKind.inteliaElement, "Intellectual assets (brands, licenses, software & other)", KeyResourceBL.IID, new List<string>{ "Buy"})
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

    //===================SLAVE===============================//
    protected SelectorForKeyResources p;
    public int mcSum;
    public int mcVat;

    public Plan_Assets(Plan_Assets master, SelectorForKeyResources product) { dad=master; this.p=product; }

    private void generateRecords(Dictionary<Guid, List<KeyResourceBL>> gsi, Dictionary<Guid, Texter> td) {
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
      us=us.Where(x=>eligible(p.ownership, x.e.selections)).ToList();
      k=us.Count;

      var su=0m;
      var va=0m;
      foreach(var o in us){
        var pure=NZ.r(o.e.amount.Value/(1m+NZ.Z(o.e.vat)));
        var vaa=o.e.amount.Value-pure;
        var t=mc.add(p.elementKind, p.title+":"+o.e.name, new MonthedDataRow(new decimal?[]{ pure, vaa, o.e.amount, o.e.vat }));
        su+=pure; va+=vaa;
        }
      var kn=(CatalogRowKind)(1+(int)p.elementKind);
      mcSum=mc.add(kn, p.title, new MonthedDataRow(su)).id;
      kn=(CatalogRowKind)(1+(int)kn);
      mcVat=mc.add(kn, p.title, new MonthedDataRow(va)).id;
      }

    private bool eligible(List<string> ownership, List<ResourceSelectionBL> selections) {
      var osis=selections.Where(x=>x.title=="Ownership type").FirstOrDefault();
      if(osis==null)
        return false;
      var t=osis.options[osis.selected];
      return ownership.Contains(t);
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
