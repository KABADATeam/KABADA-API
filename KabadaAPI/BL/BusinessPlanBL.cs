using KabadaAPIdao;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;
using System.Linq;
using Kabada;

namespace KabadaAPI {
  public class BusinessPlanBL {
    private KabadaAPIdao.BusinessPlan _o;
    public  KabadaAPIdao.BusinessPlan o { get { return _o; } set { _o=value.clone(); }}

    public Dictionary<short, List<Plan_Attribute>> a;
    public Dictionary<short, List<Plan_SpecificAttribute>> s;

    public TexterRepository textSupport;

    public BusinessPlanBL(KabadaAPIdao.BusinessPlan seed=null) {
      if(seed==null)
        _o=new KabadaAPIdao.BusinessPlan();
       else
        o=seed;
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
      var t=gAv<ProductAttribute>(PlanAttributeKind.product).Select(x=>x.title).ToList();
      return string.Join(", ", t);
      }}

    public string descriptionChannels { get {// Main channel type: Direct sale, Agent, etc. from this level
      var w=gAv<ChannelAttribute>(PlanAttributeKind.product).Select(x=>x.channel_type_id).Distinct().ToList();
      if(w.Count<1)
        return null;
      var t=textSupport.get(w).Select(x=>x.Value).ToList();
      return string.Join(", ", t);
      }}

    public string descriptionRelationship { get {//TODO maybe at the first moment selected channels, but not sure (needs more discussion)
      return "TODO: maybe at the first moment selected channels, but not sure (needs more discussion)";
      }}

    private List<string> rvs(PlanAttributeKind kind){ return gAv<RevenueAttribute>(kind).Select(x=>x.title).ToList(); }
    public string descriptionRevenue { get {// I guess, - Revenue stream names
      var t=rvs(PlanAttributeKind.revenueSegment1);
      t.AddRange(rvs(PlanAttributeKind.revenueSegment2));
      t.AddRange(rvs(PlanAttributeKind.revenueOther));
      return string.Join(", ", t);
      }}

    public string descriptionResources { get {// names
      var t=gAv<PlanResource>(PlanAttributeKind.keyResource).Select(x=>x.name).ToList();
      return string.Join(", ", t);
      }}

    public string descriptionActivities { get {//TODO activities names
      return "TODO: activities names";
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

    public string descriptionCost { get {//TODO For cost structure - we also have names
      return "TODO: For cost structure - we also have names";
      }}

    }
  }
