using Kabada;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

namespace KabadaAPI {
  partial class BusinessPlanBL {
    public string naceCode { get { return (activity==null)?null:$"{activity.Code} - {activity.Title}"; }}

    public List<string> keyRes { get { return myKeyResource_s.Select(x=>x.e.name).ToList(); }}

    public List<string> keyDist { get { return rvpL(PlanAttributeKind.keyDistributor); }}
    
    public List<string> keySupp { get { return rvpL(PlanAttributeKind.keySupplier); }}

    protected List<string> _tValues(List<Guid> us){
      var r=new List<string>();
      if(us.Count>0){
        var d=textSupport.get(us).ToDictionary(x=>x.Id);
        r=us.Select(x=>d[x].Value).ToList(); 
        }
      return r;
      }

    protected List<string> _costs(List<CostBL> us){
      var l= us.Select(x=>x.texterId).Distinct().ToList();
      l=textSupport.get(l).Where(x=>x.MasterId!=null).Select(x=>x.MasterId.Value).Distinct().ToList();
      return _tValues(l);
      }

    public List<string> costFixed { get { return _costs(myFixedCost_s); }}

    public List<string> costVariable { get { return _costs(myVariableCost_s); }}

    public List<string> channels { get {
      var w=gAv<ChannelElementBL>(PlanAttributeKind.channel).Select(x=>x.channel_type_id).ToList();
      return _tValues(w);
      } }

    public List<string> custRel { get {
      var t=new List<KabadaAPIdao.Plan_Attribute>();
      t.AddRange(gA(PlanAttributeKind.relationshipActivity1));
      t.AddRange(gA(PlanAttributeKind.relationshipActivity2));
      t.AddRange(gA(PlanAttributeKind.relationshipActivity3));

      var r=new List<string>();
      foreach(var a in t){
        if(string.IsNullOrWhiteSpace(a.AttrVal))
          continue;
        var w=Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(a.AttrVal);
        r.AddRange(w);
        }
      return r;
      }}

    public List<KeyValuePair<string, List<string>>> valProp { get {
      var r=new List<KeyValuePair<string, List<string>>>();
      var ps=myProduct_s;
      foreach(var p in ps){
        var fl=new List<string>();
        var t=p.e.product_features;
        if(t!=null && t.Count>0)
          fl=textSupport.get(t).Select(x=>x.Value).ToList();
        var w=new KeyValuePair<string, List<string>>(p.e.title, fl);
        r.Add(w);
        }
      return r;
      }}

    public List<string> custSeg { get {
      var t=new List<KabadaAPIdao.Plan_SpecificAttribute>();
      t.AddRange(gS(PlanAttributeKind.businessSegment));
      t.AddRange(gS(PlanAttributeKind.consumerSegment));
      t.AddRange(gS(PlanAttributeKind.ngoSegment));

      var r=new List<string>();
      foreach(var a in t){
        if(string.IsNullOrWhiteSpace(a.AttrVal))
          continue;
        var w=Newtonsoft.Json.JsonConvert.DeserializeObject<CustomerSegmentElementBL>(a.AttrVal);
        r.Add(w.segment_name);
        }
      return r;
      }}

    private Dictionary<Guid, KabadaAPIdao.Texter> idti;
    private string d(Guid k){
      KabadaAPIdao.Texter r=null;
      if(idti.TryGetValue(k, out r))
        return r.Value;
      return k.ToString();
      }

    public List<ValueProp_doc> valProps { get {
      var r=new List<ValueProp_doc>();
      var ps=myProduct_s;
      var idi=ps.Select(x=>x.e.product_type).Distinct().ToList();
      idi.AddRange(ps.Select(x=>x.e.price_level).Where(x=>!idi.Contains(x)).Distinct().ToList());
      idi.AddRange(ps.Select(x=>x.e.innovative_level).Where(x=>!idi.Contains(x)).Distinct().ToList());
      idi.AddRange(ps.Select(x=>x.e.quality_level).Where(x=>!idi.Contains(x)).Distinct().ToList());
      idi.AddRange(ps.Select(x=>x.e.differentiation_level).Where(x=>!idi.Contains(x)).Distinct().ToList());
      foreach(var p in ps){
        if(p.e.selected_additional_income_sources==null)
          continue;
        idi.AddRange(p.e.selected_additional_income_sources.Where(x=>!idi.Contains(x)).Distinct().ToList());
        }
      idti=textSupport.get(idi).ToDictionary(x=>x.Id);

      foreach(var p in ps){
        var w=new ValueProp_doc();
        w.title=p.e.title;
        w.prodType=d(p.e.product_type);  
        w.description=p.e.description;
        w.priceLevel=d(p.e.price_level);

        if(p.e.selected_additional_income_sources!=null)
           w.addIncomeSource=string.Join(", ", p.e.selected_additional_income_sources.Select(x=>d(x)).ToList());

        var t=p.e.product_features;
        if(t!=null && t.Count>0)
          w.productFeatures=textSupport.get(t).Select(x=>x.Value).ToList();

        w.innovLevel=d(p.e.innovative_level); 
        w.qualityLevel=d(p.e.quality_level);
        w.diffLevel=d(p.e.differentiation_level);
        r.Add(w);
        }
      return r;
      }}

    public CustomerSegment_doc custSeG { get {
      var r=new CustomerSegment_doc();
      r.business=custSeGbus();
      r.consumer=custSeGcons();
      r.publicNgo=custSeGngo();
      return r;
      }}

    private List<PublicSegment_doc> custSeGngo() {
      var r=new List<PublicSegment_doc>();
      var us=gS(PlanAttributeKind.ngoSegment).Select(x=>new NgoSegmentBL(x)).ToList();
      foreach(var x in us){
        var w=new PublicSegment_doc(){ segment_name=x.e.segment_name };
        var d=namid(x.e.minorAttributes);
        w.business_type=namil(EnumTexterKind.public_bodies_ngo, x.e.minorAttributes, d);
        r.Add(w);
        }
      return r;
      }

    private Dictionary<Guid, string> namid(Dictionary<short, List<Guid>> full){
      var idi=new List<Guid>();
      foreach(var w in full.Values)
        idi.AddRange(w);
      return textSupport.get(idi).ToDictionary(x=>x.Id, x=>x.Value);
      }

    private List<ConsumerSegment_doc> custSeGcons() {
      var r=new List<ConsumerSegment_doc>();
      var us=gS(PlanAttributeKind.consumerSegment).Select(x=>new ConsumerSegmentBL(x)).ToList();
      foreach(var x in us){
        var w=new ConsumerSegment_doc(){ segment_name=x.e.segment_name };
        var d=namid(x.e.minorAttributes);
        w.age=namil(EnumTexterKind.age_group, x.e.minorAttributes, d);
        w.education=namil(EnumTexterKind.education, x.e.minorAttributes, d);
        w.gender=namil(EnumTexterKind.gender, x.e.minorAttributes, d);
        w.geographic_location=namil(EnumTexterKind.geographic_location, x.e.minorAttributes, d);
        w.income=namil(EnumTexterKind.income, x.e.minorAttributes, d);
        r.Add(w);
        }
      return r;;
      }

    private string namil(EnumTexterKind kind, Dictionary<short, List<Guid>> minorAttributes, Dictionary<Guid, string> d) {
      var k=(short)kind;
      List<Guid> idi=null;
      if(minorAttributes.TryGetValue(k, out idi)){
        var sl=idi.Select(x=>d[x]).ToList();
        return string.Join(", ", sl);
        }
      return null;
      }

    private List<BusinessSegment_doc> custSeGbus() {
      var r=new List<BusinessSegment_doc>();
      var us=gS(PlanAttributeKind.businessSegment).Select(x=>new BusinessSegmentBL(x)).ToList();
      foreach(var x in us){
        var w=new BusinessSegment_doc(){ segment_name=x.e.segment_name };
        var d=namid(x.e.minorAttributes);
        w.business_type=namil(EnumTexterKind.industry, x.e.minorAttributes, d);
        w.company_size=namil(EnumTexterKind.company_size, x.e.minorAttributes, d);
        w.geographic_location=namil(EnumTexterKind.geographic_location, x.e.minorAttributes, d);
        r.Add(w);
        }
      return r;
      }

    public List<Channel_doc> channelS { get {
      var r=new List<Channel_doc>();
      var us=gAv<ChannelElementBL>(PlanAttributeKind.channel);
      foreach(var c in us){
        var w=new Channel_doc();
        r.Add(w);
        w.channelType=textSupport.getById(c.channel_type_id).Value;
        var t=_tValues(c.distribution_channels_id);
        w.distributionChannels=t.Count<1?"-":string.Join(", ", t);
        w.products=string.Join(", ", myProduct_s.Where(x=>c.product_id.Contains(x.id)).Select(x=>x.e.title).ToList());
        }
      return r;
      }}

    public CustRel_doc CustomerRelationship { get {
      var r=new CustRel_doc();
      var acti=textSupport.getCustomerRelationshipActions().ToDictionary(x=>x.Id);
      r.convCust=makeCustRel(acti,  PlanAttributeKind.relationshipActivity3);
      r.getCust=makeCustRel(acti,  PlanAttributeKind.relationshipActivity1);
      r.keepCust=makeCustRel(acti,  PlanAttributeKind.relationshipActivity2);

      return r;
      }}

    private List<CustRelElement_doc> makeCustRel(Dictionary<Guid, KabadaAPIdao.Texter> acti, PlanAttributeKind kind) {
      var r=new List<CustRelElement_doc>();
      var us=gA(kind);
      foreach(var a in us){
        var w=new CustRelElement_doc(){ action=acti[a.TexterId].Value };
        var channels=Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(a.AttrVal);
        w.channel=string.Join(", ", channels);
        r.Add(w);
        }
      return r;
      }

    public List<KeyRes_doc> keyResources { get {
      var r=new List<KeyRes_doc>();

      var types=textSupport.getKeyResourceTypes(null).ToDictionary(x=>x.Id);     

      foreach(var o in myKeyResource_s){
        var w=new KeyRes_doc(){ name=o.e.name };
        w.category=types[o.texterId].Value; //
        w.ownership=KeyResourceElementBL.selectionValue(o.e.selections);
        w.frequecy=KeyResourceElementBL.selectionValue(o.e.selections, KeyResourceBL.Frequency);
        r.Add(w);
        }
      return r;
      }}

    public List<KeyValuePair<string, List<KeyAct_doc>>> keyActivities { get {
      var r=new List<KeyValuePair<string, List<KeyAct_doc>>>();

      var prodi=myProduct_s;
      if(prodi.Count>0){
        var idi=prodi.Select(x=>(Guid?)x.id).ToList();
        var d=prodi.ToDictionary(x=>x.id);
        var txi=textSupport.getActivitiesTypesQ().ToDictionary(x=>x.Id);
        var acti=new UniversalAttributeRepository(textSupport.blContext).byMasters(idi).Select(x=>new KeyActivityBL(x)).ToList();

        foreach(var p in prodi){
          var macti=acti.Where(x=>x.masterId==p.id);
          var dacti=new List<KeyAct_doc>();
          foreach(var a in macti){
            var su=txi[a.categoryId.Value];
            var ty=txi[su.MasterId.Value];
            var an=new KeyAct_doc(){  desc=a.e.description, subType=su.Value, type=ty.Value, name=a.e.name };
            dacti.Add(an);
            }
          var w=new KeyValuePair<string, List<KeyAct_doc>>(p.e.title, dacti);
          r.Add(w);
          }
        }

      return r;
      }}

    private Dictionary<Guid, string> partnerTypes;

    private List<KeyPartnersElement_doc> _getKeyPartners(PlanAttributeKind kind){
      var t1=gA(kind);
      if(t1==null || t1.Count<1)
        return null;
      var r=new List<KeyPartnersElement_doc>();
      foreach(var t2 in t1){
        var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KeyPartnersAttribute>(t2.AttrVal);
        var w=new KeyPartnersElement_doc()
          { comment=o.comment, web=o.website, priority=o.is_priority?"Yes":"No", company=o.name, partnerType=partnerTypes[t2.TexterId] };
        r.Add(w);
        }
      return r;
      }

    public KeyPartners_doc keyPartners { get {
      var r=new KeyPartners_doc();
      partnerTypes=textSupport.getKeyPartnerMeta().ToDictionary(x=>x.Id, x=>x.Value);

      r.distributors= _getKeyPartners(PlanAttributeKind.keyDistributor);
      r.others= _getKeyPartners(PlanAttributeKind.otherKeyPartner);
      r.suppliers= _getKeyPartners(PlanAttributeKind.keySupplier);
      return r;
      }}

    public Costs_doc Costs { get { 
      var r=new Costs_doc();
      r.fixedCosts=_detailedCosts(myFixedCost_s);
      r.variableCosts=_detailedCosts(myVariableCost_s);
      return r;
      }}

    private List<CostElement_doc> _detailedCosts(List<CostBL> us) {
      if(us==null || us.Count<1)
        return null;
      var r=new List<CostElement_doc>();
      var idi = us.Select(x => x.texterId).Distinct().ToList();    // type texter Ids used in CostBL
      var ti = textSupport.get(idi).ToDictionary(x => x.Id, x => x.MasterId);  // types
      var tidi=ti.Values.Where(x=>x!=null).Select(x=>x.Value).Distinct().ToList();
      tidi.AddRange(idi);
      var txi=textSupport.get(tidi).ToDictionary(x=>x.Id, x=>x.Value);
      foreach(var o in us){
        var w=new CostElement_doc(){ name=o.e.name, desc=o.e.description, category="??", subCategory=txi[o.texterId] };
        var ct=ti[o.texterId];
        if(ct!=null)
          w.category=txi[ct.Value];
        r.Add(w);
        }
      return r;
      }

    public Swot_doc Swot { get { 
      var r=new Swot_doc();
      var swots=gA(PlanAttributeKind.swot).OrderBy(x=>x.OrderValue).ToList();
      var idi=swots.Select(x=>x.TexterId).Distinct().ToList();
      var txi=textSupport.get(idi).ToDictionary(x=>x.Id);
      r.opportunities=new List<string>();
      r.strengths=new List<string>();
      r.threats=new List<string>();
      r.weaknesses=new List<string>();

      foreach(var a in swots){
        var v=short.Parse(a.AttrVal);
        var t=txi[a.TexterId].Value;
        switch(v){
          case 3: r.opportunities.Add(t); break;
          case 4: r.threats.Add(t); break;
          case 1: r.strengths.Add(t); break;
          case 2: r.weaknesses.Add(t); break;
          }
        }
      return r;
      }}

    public RevenueStream_doc revenuE { get {
      var r=new RevenueStream_doc();
      r.consumer=_rev(PlanAttributeKind.revenueSegment1);
      r.business=_rev(PlanAttributeKind.revenueSegment2);
      r.publicNgo=_rev(PlanAttributeKind.revenueOther);
      return r;
      }}

 
    private List<RevenueStreamElement_doc> _rev(PlanAttributeKind kind) {
      var segi=gA(kind);
      var r=new List<RevenueStreamElement_doc>();
      foreach(var o in segi){
        var bo=new RevenueStreamBL(o);
        var tidi=new List<Guid>{ bo.e.price_type_id, bo.e.stream_type_id };
        var didi=textSupport.get(tidi).ToDictionary(x=>x.Id);
        var p=didi[bo.e.price_type_id];
        
        var w=new RevenueStreamElement_doc(){ consumers=(bo.e.namesOfSegments==null || bo.e.namesOfSegments.Count<1)?"":string.Join(", ", bo.e.namesOfSegments),
                 name=didi[bo.e.stream_type_id].Value, prices=p.Value };

        var m=p.MasterId.Value;
        w.pricingType=textSupport.getById(m).Value;

        r.Add(w);
        }
      return r;
      }

    

    public BPunloaded unloadForAI(){
      var r=new BPunloaded(){ businessPlan_id=o.Id, country=o.CountryId.Value, language=o.LanguageId.Value, nace=o.ActivityID.Value};
      r.custSegs=new CustomerSegmentAI(){ business=businessSegAI(), consumer=consumerSegAI(), publicNgo=publicNgoAI() };
      r.channels=getAIchannels();
      r.keyActivities=getKeyActsAI();
      r.keyPartners=getKeyPartnersAI();
      r.keyResources=getKeyResourcesAI();
      r.custRelationship=getCustRelationshipAI();
      r.costs=getCostsAI();
      r.swot=getSwotAI();
      r.revenue=getRevenueAI();
      r.valueProposition=getValuePropositionAI();
      return r;
      }

    private List<ValuePropAI> getValuePropositionAI() {
      var ps=myProduct_s;
      if(ps==null || ps.Count<1)
        return null;
      var r=ps.Select(p=>
             new ValuePropAI(){ title=p.e.title, description=p.e.description
              , prodType=p.e.product_type, priceLevel=p.e.price_level, innovLevel=p.e.innovative_level, diffLevel=p.e.differentiation_level, qualityLevel=p.e.quality_level
              , addIncomeSource=p.e.selected_additional_income_sources, productFeatures=p.e.product_features
              }).ToList();  
      return r;
      }

    private RevenueStreamAI getRevenueAI() {
      var r=new RevenueStreamAI();
      r.consumer=getRevenueAI(PlanAttributeKind.revenueSegment1);
      r.business=getRevenueAI(PlanAttributeKind.revenueSegment2);
      r.publicNgo=getRevenueAI(PlanAttributeKind.revenueOther);
      return r;
      }

    private List<RevenueStreamElementAI> getRevenueAI(PlanAttributeKind kind) {
      var segi=gA(kind);
      var r=new List<RevenueStreamElementAI>();
      foreach(var o in segi){
        var bo=new RevenueStreamBL(o);
        var tidi=new List<Guid>{ bo.e.price_type_id, bo.e.stream_type_id };
        var didi=textSupport.get(tidi).ToDictionary(x=>x.Id);
        var p=didi[bo.e.price_type_id];
        
        var w=new RevenueStreamElementAI(){ segments=bo.e.namesOfSegments, category=bo.e.stream_type_id, price=bo.e.price_type_id };
        w.pricingType=p.MasterId.Value;

        r.Add(w);
        }
      return r;
      }

    private SwotAI getSwotAI() {
      var r=new SwotAI();
      var swots=gA(PlanAttributeKind.swot).OrderBy(x=>x.OrderValue).ToList();
      if(swots==null || swots.Count<1)
        return r;
      var idi=swots.Select(x=>x.TexterId).Distinct().ToList();
      var txi=textSupport.get(idi).ToDictionary(x=>x.Id);
      r.opportunities=new List<Guid>();
      r.strengths=new List<Guid>();
      r.threats=new List<Guid>();
      r.weaknesses=new List<Guid>();

      foreach(var a in swots){
        var v=short.Parse(a.AttrVal);
        switch(v){
          case 3: r.opportunities.Add(a.TexterId); break;
          case 4: r.threats.Add(a.TexterId); break;
          case 1: r.strengths.Add(a.TexterId); break;
          case 2: r.weaknesses.Add(a.TexterId); break;
          }
        }
      return r;
      }

    private CostAI getCostsAI() {
      var r=new CostAI();
      r.fixedCosts=getCostsAI(myFixedCost_s);
      r.variableCosts=getCostsAI(myVariableCost_s);
      return r;
      }

    private List<CostElementAI> getCostsAI(List<CostBL> costs) {
      if(costs==null || costs.Count<1)
        return null;
      var r=new List<CostElementAI>();
      var idi = costs.Select(x => x.texterId).Distinct().ToList();    // type texter Ids used in CostBL
      var ti = textSupport.get(idi).ToDictionary(x => x.Id, x => x.MasterId);  // types
      foreach(var o in costs){
        var w=new CostElementAI(){ name=o.e.name, desc=o.e.description, subCategory=o.texterId };
        var ct=ti[o.texterId];
        if(ct!=null)
          w.category=ct.Value;
        r.Add(w);
        }
      return r;
      }

    private List<KeyResourceAI> getKeyResourcesAI() {
      return myKeyResource_s.Select(x=>new KeyResourceAI(){ name=x.e.name, category=x.e.type_id/*, ownership=? */ }).ToList();
      }

    private KeyPartnerAI getKeyPartnersAI() {
      var r=new KeyPartnerAI();
      partnerTypes=textSupport.getKeyPartnerMeta().ToDictionary(x=>x.Id, x=>x.Value);
      r.distributors=getKeyPartnersAI(PlanAttributeKind.keyDistributor);
      r.others=getKeyPartnersAI(PlanAttributeKind.otherKeyPartner);
      r.suppliers=getKeyPartnersAI(PlanAttributeKind.keySupplier);
      return r;
      }

    private List<KeyPartnersElementAI> getKeyPartnersAI(PlanAttributeKind kind) {
      var t1=gA(kind);
      if(t1==null || t1.Count<1)
        return null;
      var r=new List<KeyPartnersElementAI>();
      foreach(var t2 in t1){
        var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KeyPartnersAttribute>(t2.AttrVal);
        var w=new KeyPartnersElementAI()   
          { comment=o.comment, web=o.website, company=o.name, partnerType=t2.TexterId, priority=o.is_priority?"Yes":"No" };
        r.Add(w);
        }
      return r;
      }

    private List<KeyValuePair<string, List<KeyActivityAI>>> getKeyActsAI() {
      var r=new List<KeyValuePair<string, List<KeyActivityAI>>>();

      var prodi=myProduct_s;
      if(prodi.Count>0){
        var idi=prodi.Select(x=>(Guid?)x.id).ToList();
        var d=prodi.ToDictionary(x=>x.id);
        var txi=textSupport.getActivitiesTypesQ().ToDictionary(x=>x.Id);
        var acti=new UniversalAttributeRepository(textSupport.blContext).byMasters(idi).Select(x=>new KeyActivityBL(x)).ToList();

        foreach(var p in prodi){
          var macti=acti.Where(x=>x.masterId==p.id);
          var dacti=new List<KeyActivityAI>();
          foreach(var a in macti){
            var su=txi[a.categoryId.Value];
            //var ty=txi[su.MasterId.Value];
            var an=new KeyActivityAI(){  desc=a.e.description, subType=a.categoryId.Value, type=su.MasterId.Value, name=a.e.name };
            dacti.Add(an);
            }
          var w=new KeyValuePair<string, List<KeyActivityAI>>(p.e.title, dacti);
          r.Add(w);
          }
        }
      return r;
      }

    private CustomerRelationshipAI getCustRelationshipAI() {
      var r=new CustomerRelationshipAI();
      r.getCust=aiRels(PlanAttributeKind.relationshipActivity1);
      r.keepCust=aiRels(PlanAttributeKind.relationshipActivity2);
      r.convCust=aiRels(PlanAttributeKind.relationshipActivity3);
      return r;
      }

    private List<CustRelElementAI> aiRels(PlanAttributeKind relationshipKind) { //TODO
      var t=gA(relationshipKind);
      if(t==null || t.Count<1)
        return null;
      var r=new List<CustRelElementAI>();
      foreach(var a in t){
        var z=Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(a.AttrVal);
        var w=new CustRelElementAI(){ channel=z, action=a.TexterId };
        r.Add(w);
        }
      return r;
      }

    private List<ChannelAI> getAIchannels() {
      var us=gAv<ChannelElementBL>(PlanAttributeKind.channel);
      var r=us.Select(c=>new ChannelAI(){ channelType=c.channel_type_id, distributionChannels=c.distribution_channels_id, products=c.product_id }).ToList();
      return r;
      }

    private List<PublicSegmentAI> publicNgoAI() {
      var r=new List<PublicSegmentAI>();
      var t=gS(PlanAttributeKind.ngoSegment);
      foreach(var w in t){
        var z=new NgoSegmentBL(w);
        var o=new PublicSegmentAI(){ segment_id=w.Id };
        o.business_type=minors(EnumTexterKind.public_bodies_ngo ,z.e.minorAttributes);
        r.Add(o);
        }
      return r;
      }

    private List<ConsumerSegmentAI> consumerSegAI() {
      var r=new List<ConsumerSegmentAI>();
      var t=gS(PlanAttributeKind.consumerSegment);
      foreach(var w in t){
        var z=new ConsumerSegmentBL(w);
        var o=new ConsumerSegmentAI(){ segment_id=w.Id };
        o.age=minors(EnumTexterKind.age_group ,z.e.minorAttributes);
        o.education=minors(EnumTexterKind.education ,z.e.minorAttributes);
        o.geographic_location=minors(EnumTexterKind.geographic_location ,z.e.minorAttributes);
        o.gender=minors(EnumTexterKind.gender ,z.e.minorAttributes);
        o.income=minors(EnumTexterKind.income ,z.e.minorAttributes);
        r.Add(o);
        }
      return r;
      }

    private List<Guid> minors(EnumTexterKind kind, Dictionary<short, List<Guid>> minorAttributes){
      List<Guid> w=null;
      if(!minorAttributes.TryGetValue((short)kind, out w))
        return null;
      return w;
      }

    private List<BusinessSegmentAI> businessSegAI() {
      var r=new List<BusinessSegmentAI>();
      var t=gS(PlanAttributeKind.businessSegment);
      foreach(var w in t){
        var z=new BusinessSegmentBL(w);
        var o=new BusinessSegmentAI(){ segment_id=w.Id };
        o.business_type=minors(EnumTexterKind.industry ,z.e.minorAttributes);
        o.company_size=minors(EnumTexterKind.company_size ,z.e.minorAttributes);
        o.geographic_location=minors(EnumTexterKind.geographic_location ,z.e.minorAttributes);
        r.Add(o);
        }
      return r;
      }
    }
  }
