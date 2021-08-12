using KabadaAPIdao;
using System.Collections.Generic;

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

      return ((decimal)_k)/_n;
      }}
    }
  }
