using KabadaAPIdao;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;
using System.Linq;

namespace KabadaAPI {
  public class BusinessPlanBL {
    private BusinessPlan _o;
    public  BusinessPlan o { get { return _o; } set { _o=value.clone(); }}

    public Dictionary<short, List<Plan_Attribute>> a;
    public Dictionary<short, List<Plan_SpecificAttribute>> s;

    public BusinessPlanBL(BusinessPlan seed=null) {
      if(seed==null)
        _o=new BusinessPlan();
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
      
      count(o.Activity!=null);

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

    public string descriptionCustomerSegments { get {
      var r=gSv(PlanAttributeKind.consumerSegment);
      r.AddRange(gSv(PlanAttributeKind.businessSegment));
      r.AddRange(gSv(PlanAttributeKind.ngoSegment));
      return r.Count<1?null:string.Join(" ,", r);
      }}
    }
  }
