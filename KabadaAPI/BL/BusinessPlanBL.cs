﻿using KabadaAPIdao;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;
using System.Linq;
using Kabada;
using System;
using Newtonsoft.Json;

namespace KabadaAPI {
  public partial class BusinessPlanBL {
    private KabadaAPIdao.BusinessPlan _o;
    public  KabadaAPIdao.BusinessPlan o { get { return _o; } set { _o=value; }}

    private BPjoin _j;
    public User user { get { return _j.us; }}
    public Activity activity { get { return _j.ac; }}
    public KabadaAPIdao.Industry industry { get { return _j.ind; }}

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

    public BusinessPlanBL(KabadaAPIdao.BusinessPlan seed, bool forUpdate=false) {
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

    public BusinessPlanBL(BPjoin seed=null, bool forUpdate=false) {
      if(seed==null){
        _j=new BPjoin(){ bp=new KabadaAPIdao.BusinessPlan()};
        }
       else {
        if(forUpdate)
          _j=seed;
         else
          _j=seed.clone();
        }
      o=_j.bp;
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
      var r=gA(kind).OrderBy(x=>x.OrderValue).Select(x=>Newtonsoft.Json.JsonConvert.DeserializeObject<T>( x.AttrVal)).ToList();
      return r;
      }

    private List<KeyValuePair<Guid,T>> gAvP<T>(PlanAttributeKind kind) where T : class {
      var r = gA(kind).OrderBy(x => x.OrderValue).Select(x => new KeyValuePair<Guid, T>(x.Id, Newtonsoft.Json.JsonConvert.DeserializeObject<T>(x.AttrVal))).ToList();
      return r;
    }

    public string descriptionCustomerSegments { get {// segments name
      var t=custSeg;
      return string.Join(", ", t);
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

    public string descriptionRelationship { get {//names of selected channels
      var t=custRel;
      return string.Join(", ", t);
      }}

    private List<Guid> rvs(PlanAttributeKind kind){ return gAv<RevenueStreamElementBL>(kind).Select(x=>x.stream_type_id).ToList(); }


    public List<string> revenue { get {
      var w=rvs(PlanAttributeKind.revenueSegment1);
      w.AddRange(rvs(PlanAttributeKind.revenueSegment2));
      w.AddRange(rvs(PlanAttributeKind.revenueOther));
      w=w.Distinct().ToList();
      var ti=textSupport.get(w).ToDictionary(x=>x.Id, x=>x.Value);
      var t=w.Select(x=>ti[x]).ToList();
      return t;
      }}

    public string descriptionRevenue { get {// I guess, - Revenue stream names
      var t=revenue;
      return string.Join(", ", t);
      }}

    public string descriptionResources { get {// names
      var t=gAv<KeyResourceElementBL>(PlanAttributeKind.keyResource).Select(x=>x.name).ToList();
      return string.Join(", ", t);
      }}

    public List<string> namesActivities { get {// activities names
      var pi=gA((short)PlanAttributeKind.product).Select(x=>(Guid?)x.Id).ToList();
      if(pi.Count<1)
        return null;
      var t=new UniversalAttributeRepository(textSupport.blContext).byMasters(pi).Where(x=>KeyActivityBL.KIND==x.Kind)
            .Select(x=>new KeyActivityBL(x).e.name).ToList();
      return t;
      }}

    public string descriptionActivities { get {// activities names
      var t=namesActivities;
      if(t==null)
        return null;
      return string.Join(", ", t);
      }}


    private List<string> rvp(PlanAttributeKind kind){ return gAv<KeyPartnersAttribute>(kind).Select(x=>x.name).ToList(); }

    private List<string> rvpL(PlanAttributeKind kind){
      return gAv<KeyPartnersAttribute>(kind).Select(x=>x.name).ToList();
      }

    private string rvp(string prefix, string name, PlanAttributeKind kind){
      //var t=gAv<KeyPartnersAttribute>(kind).Select(x=>x.name).ToList();
      var t=rvpL(kind);
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

    private List<InvestmentElementBL> ownMoney(){
      var r=new List<InvestmentElementBL>();
      if(e.startup.own_money!=null)      // basic own money
        r.Add(new InvestmentElementBL("Own Money", e.startup.own_money));
      var m2=new InvestmentElementBL("Own extra money", e.startup.own_money_short);
      if(e.working_capitals!=null)
        m2.AddRange(e.working_capitals.Select(x=>x==null?null:x.own_amount).ToList());
      var t=m2.Where(x=>x!=null).FirstOrDefault();
      if(t!=null)
        r.Add(m2);
      return r;
      }

    private List<LoanElementBL> loanList(){
      var r=new List<LoanElementBL>();
      var s=e.startup;
      if(s.loan_amount!=null && s.loan_amount.Value>0){
        var w=new LoanElementBL("Long term", s.loan_amount){
                 payment_period=(short)NZ.Z(s.payment_period, pPeriod)
               , interest_rate=NZ.Z(s.interest_rate)
               , grace_period=(short)NZ.Z(s.grace_period)
               , revenueTitle="Loan (LongTerm) - Investment"
               };
        //var w=new Plan_Loan("Long term", s.period, s.grace_period, s.interest_rate, s.payment_period, s.loan_amount);
        r.Add(w);
        }

      // TODO extra loan
      if(s.payment_period_short!=null){
        var m2 = new LoanElementBL("Short term", s.loan_amount_short){
          payment_period=(short)NZ.Z(s.payment_period_short), interest_rate=NZ.Z(s.interest_rate_short), grace_period=(short)NZ.Z(s.grace_period_short),
          revenueTitle="Loan (ShortTerm) - Working Capital" };
        if(e.working_capitals!=null)
          m2.AddRange(e.working_capitals.Select(x=>x==null?null:x.loan_amount).ToList());
        var t=m2.Where(x=>x!=null).FirstOrDefault();
        if(t!=null)
          r.Add(m2);
        }
      //end TODO-replace with real data

      return r;
      }

    private string _swot(string name, List<string> texts){
      if(texts==null || texts.Count<1)
        return "";
      var r=$"{name}: {string.Join(", ", texts)} ";
      return r;
      }

    public string descriptionSwot { get {
      var t=Swot;
      var r="";
      r+=_swot("Opportunities", t.opportunities);
      r+=_swot("Strengths", t.strengths);
      r+=_swot("Threats", t.threats);
      r+=_swot("Weaknesses", t.weaknesses);
      return r;
      } }
    
    }
  }
