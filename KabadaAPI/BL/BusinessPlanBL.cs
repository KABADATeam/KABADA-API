﻿using KabadaAPIdao;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;
using System.Linq;
using Kabada;
using System;

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
      var t=gAv<CostElementBL>(PlanAttributeKind.fixedCost).Select(x=>x.name).ToList();
      t.AddRange(gAv<CostElementBL>(PlanAttributeKind.variableCost).Select(x=>x.name).ToList());
      return string.Join(", ", t);
      }}

    }
  }
