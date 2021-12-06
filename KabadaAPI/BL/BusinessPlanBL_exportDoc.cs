using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

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
      var t=gA(PlanAttributeKind.relationshipActivity1);
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
      var t=gS(PlanAttributeKind.businessSegment);
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
    }
  }
