using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

namespace KabadaAPI {
  partial class BusinessPlanBL {
    public string naceCode { get { return (o.Activity==null)?null:$"{o.Activity.Code} - {o.Activity.Title}"; }}

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
           w.addIncomeSource=string.Join(",", p.e.selected_additional_income_sources.Select(x=>d(x)).ToList());

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
      return r;
      }}

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
        return string.Join(",", sl);
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
      return r;;
      }

    public List<Channel_doc> channelS { get {
      var r=new List<Channel_doc>();
      var us=gAv<ChannelElementBL>(PlanAttributeKind.channel);
      foreach(var c in us){
        var w=new Channel_doc();
        r.Add(w);
        w.channelType=textSupport.getById(c.channel_type_id).Value;
        w.distributionChannels=string.Join(",", _tValues(c.distribution_channels_id));
        w.products=string.Join(",", myProduct_s.Where(x=>c.product_id.Contains(x.id)).Select(x=>x.e.title).ToList());
        }
      return r;
      }}
    }
  }
