using KabadaAPIdao;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;
using System.Linq;
using Kabada;
using System;
using Newtonsoft.Json;

namespace KabadaAPI {
  public class BusinessPlanBL {
    private KabadaAPIdao.BusinessPlan _o;
    public  KabadaAPIdao.BusinessPlan o { get { return _o; } set { _o=value; }}

    private BusinessPlanElementBL _e;
    public BusinessPlanElementBL e {
      get {
        if(_e==null){
          if(_o.AttrVal==null)
            _e=new BusinessPlanElementBL();
           else
            _e=JsonConvert.DeserializeObject<BusinessPlanElementBL>(_o.AttrVal);
          }
        return _e;
        }
      set { _e=value;}
      }

    public KabadaAPIdao.BusinessPlan unload(){
      o.AttrVal=JsonConvert.SerializeObject(_e, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); 
      return o;
      }

    public Dictionary<short, List<Plan_Attribute>> a;
    public Dictionary<short, List<Plan_SpecificAttribute>> s;

    public TexterRepository textSupport;

    public BusinessPlanBL(KabadaAPIdao.BusinessPlan seed=null, bool forUpdate=false) {
      if(seed==null)
        _o=new KabadaAPIdao.BusinessPlan();
       else {
        if(forUpdate)
          o=seed;
         else
          o=seed.clone();
        }
      a=new Dictionary<short, List<Plan_Attribute>>();
      s=new Dictionary<short, List<Plan_SpecificAttribute>>();
      }

    private int _n;
    private int _k;
    private void count(bool f){
      _n++;
      if(f)
        _k++;
      }

    public decimal percentCompleted { get {
      _n=0; _k=0;

      count(o.IsChannelsCompleted);
      count(o.IsCostCompleted);
      count(o.IsCustomerRelationshipCompleted);
      count(o.IsCustomerSegmentsCompleted);
      count(o.IsPartnersCompleted);
      count(o.IsPropositionCompleted);
      count(o.IsResourcesCompleted);
      count(o.IsRevenueCompleted);
      count(o.IsSwotCompleted);
      count(o.IsActivitiesCompleted);

      return ((decimal)_k)/_n;
      }}

    private List<Plan_Attribute> gA(short kind){
      List<Plan_Attribute> r=null;
      if(a.TryGetValue(kind, out r))
        return r;
      return new List<Plan_Attribute>();
      }
    private List<Plan_Attribute> gA(PlanAttributeKind kind){ return gA((short)kind); }

    private List<Plan_SpecificAttribute> gS(short kind){
      List<Plan_SpecificAttribute> r=null;
      if(s.TryGetValue(kind, out r))
        return r;
      return new List<Plan_SpecificAttribute>();
      }
    private List<Plan_SpecificAttribute> gS(PlanAttributeKind kind){ return gS((short)kind); }

    private List<string> gSv(PlanAttributeKind kind){
      var r=gS((short)kind).OrderBy(x=>x.OrderValue).Select(x=>x.AttrVal).ToList();
      return r;
      }

    private List<T> gAv<T>(PlanAttributeKind kind) where T:class {
      var r=gA(kind).Select(x=>Newtonsoft.Json.JsonConvert.DeserializeObject<T>( x.AttrVal)).ToList();
      return r;
      }

    public string descriptionCustomerSegments { get {//TODO Maybe info from the first two fields: Age groups and Gender
      return "TODO: Maybe info from the first two fields: Age groups and Gender";
      //var r=gSv(PlanAttributeKind.consumerSegment);
      //r.AddRange(gSv(PlanAttributeKind.businessSegment));
      //r.AddRange(gSv(PlanAttributeKind.ngoSegment));
      //return r.Count<1?null:string.Join(" ,", r);
      }}

    public string descriptionPropostion { get { // product names
      var t=gAv<ProductElementBL>(PlanAttributeKind.product).Select(x=>x.title).ToList();
      return string.Join(", ", t);
      }}

    public string descriptionChannels { get {// Main channel type: Direct sale, Agent, etc. from this level
      var w=gAv<ChannelElementBL>(PlanAttributeKind.channel).Select(x=>x.channel_type_id).Distinct().ToList();
      if(w.Count<1)
        return null;
      var t=textSupport.get(w).Select(x=>x.Value).ToList();
      return string.Join(", ", t);
      }}

    public string descriptionRelationship { get {//TODO maybe at the first moment selected channels, but not sure (needs more discussion)
      return "TODO: maybe at the first moment selected channels, but not sure (needs more discussion)";
      }}

    private List<Guid> rvs(PlanAttributeKind kind){ return gAv<RevenueStreamElementBL>(kind).Select(x=>x.stream_type_id).ToList(); }
    public string descriptionRevenue { get {// I guess, - Revenue stream names
      //return "TODO: I guess, - Revenue stream names";
      var w=rvs(PlanAttributeKind.revenueSegment1);
      w.AddRange(rvs(PlanAttributeKind.revenueSegment2));
      w.AddRange(rvs(PlanAttributeKind.revenueOther));
      w=w.Distinct().ToList();
      var ti=textSupport.get(w).ToDictionary(x=>x.Id, x=>x.Value);
      var t=w.Select(x=>ti[x]).ToList();
      return string.Join(", ", t);
      }}

    public string descriptionResources { get {// names
      var t=gAv<KeyResourceElementBL>(PlanAttributeKind.keyResource).Select(x=>x.name).ToList();
      return string.Join(", ", t);
      }}

    public string descriptionActivities { get {// activities names
      var pi=gA((short)PlanAttributeKind.product).Select(x=>(Guid?)x.Id).ToList();
      if(pi.Count<1)
        return null;
      var t=new UniversalAttributeRepository(textSupport.blContext).byMasters(pi).Where(x=>KeyActivityBL.KIND==x.Kind)
            .Select(x=>new KeyActivityBL(x).e.name).ToList();
      return string.Join(", ", t);
      }}

    private List<string> rvp(PlanAttributeKind kind){ return gAv<KeyPartnersAttribute>(kind).Select(x=>x.name).ToList(); }
    private string rvp(string prefix, string name, PlanAttributeKind kind){
      var t=gAv<KeyPartnersAttribute>(kind).Select(x=>x.name).ToList();
      if(t.Count<1)
        return prefix;
      return (string.IsNullOrWhiteSpace(prefix)?"":prefix+" ")+name+": "+string.Join(", ", t);
      }
    public string descriptionPartners { get { // String format -> Distributors: Name #1, Name #2,.. Suppliers: Name #1, Name #2
      string r=null;
      r=rvp(r, "Distributors", PlanAttributeKind.keyDistributor);
      r=rvp(r, "Suppliers", PlanAttributeKind.keySupplier);
      r=rvp(r, "Other", PlanAttributeKind.otherKeyPartner);
      return r;
      }}

    public string descriptionCost { get {// For cost structure - we also have names
      //var t=gAv<CostElementBL>(PlanAttributeKind.fixedCost).Select(x=>x.name).ToList();
      //t.AddRange(gAv<CostElementBL>(PlanAttributeKind.variableCost).Select(x=>x.name).ToList());
      var t=myCost_s.Select(x=>x.e.name).ToList();
      return string.Join(", ", t);
      }}

    private List<ProductBL> myProduct_s { get { return gA(PlanAttributeKind.product).Select(x=>new ProductBL(x, false)).ToList(); }}

    private List<CostBL> myFixedCost_s { get { return gA(PlanAttributeKind.fixedCost).Select(x=>new CostBL(x, false)).ToList(); }}
    private List<CostBL> myVariableCost_s { get { return gA(PlanAttributeKind.variableCost).Select(x=>new CostBL(x, false)).ToList(); }}
    private List<CostBL> myCost_s { get {var r=myFixedCost_s; r.AddRange(myVariableCost_s); return r; }}

    private List<KeyResourceBL> myKeyResource_s { get { return gA(PlanAttributeKind.keyResource).Select(x=>new KeyResourceBL(x, false)).ToList(); }}

    private CashFlowTable initialRevenue { get {
      var br=new CashFlowTable();
      var r=new List<CashFlowRow>();
      br.rows=r;
      r.Add(new CashFlowRow("Owner's contribution", (e.startup.loan_amount==null || e.startup.total_investments==null)?null:e.startup.total_investments-e.startup.loan_amount));
      r.Add(new CashFlowRow("Loan from bank/leasing company", e.startup.loan_amount));
      
      br.summaries=new List<CashFlowRow>(){ new CashFlowRow("Total initial revenue", e.startup.total_investments)};
      return br;
      }}

    public CashFlowTable salesForecast { get {
      var r=new CashFlowTable(){ rows=new List<CashFlowRow>() };
      var vats=new CashFlowRow("VAT received - (PVN likmes), not calculated for export part outside EU", period: this.e.startup.period);
      var n=(short)(vats.monthlyValue.Count-1);
      var pi=myProduct_s;
      foreach(var p in pi){
        var rw=new CashFlowRow(p.e.title, period: n);
        r.rows.Add(rw);
        for(var m=1; m<=n; m++){
          var euS=p.euSale(m);
          rw.monthlyValue[m]=CashFlowRow.Sum(euS, p.noneuSale(m));
          if(euS!=null){
            var pc=p.e.salesForcast.sales_forecast_eu.Where(x=>x.month==m).FirstOrDefault();
            vats.monthlyValue[m]=CashFlowRow.Sum(vats.monthlyValue[m], pc.vat*euS/100);
            }
          }
        rw.totals();
        }
      r.summaries=new List<CashFlowRow>(){ r.summRow("TOTAL revenue from core business", r.rows), vats };
      vats.totals();
      var tr=r.summRow("TOTAL REVENUE", r.summaries);
      tr.monthlyValue[0]=this.e.startup.total_investments;
      r.summaries.Add(tr);
      return r;
      } }

    public CashFlowTable investments { get {
      var r=new CashFlowTable();
      var rsi=myKeyResource_s;
      var idi=rsi.Select(x=>x.texterId).Distinct().ToList();
      var ti=textSupport.get(idi).ToDictionary(x=>x.Id, x=>x.MasterId);
      var midi=ti.Where(x=>x.Value!=null && x.Value!=KeyResourceBL.HID).Select(x=>(Guid)x.Value).Distinct().ToList();
      var mi=textSupport.get(midi).ToDictionary(x=>x.Id);
      var gsi=myKeyResource_s.GroupBy(x=>ti[x.texterId]).ToDictionary(g => g.Key, g => g.Where(x=>x.e.amount!=null).ToList());
      var rws=new List<CashFlowRow>();
      foreach(var o in mi){
        var rw=new CashFlowRow(o.Value.Value);
        rws.Add(rw);
        var li=gsi[o.Key];
        if(li.Count>0)
          rw.monthlyValue[0]=li.Sum(x=>x.e.amount);
        rw.totals();
        }
      if(rws.Count>0)
        r.rows=rws;
      return r;
      } }

    public CashFlow myCashFlow(){
      var r=new CashFlow();
      r.initialRevenue=initialRevenue;
      r.salesForecast=salesForecast;
      r.investments=investments;
      return r;
      }
    }
  }
