using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public class Plan_AttributeRepository : BaseRepository {
    public enum PlanAttributeKind { swot=1, keyResource=2, keyDistributor=3, keySupplier=4, otherKeyPartner=5, product=6
                                    ,fixedCost=7, variableCost=8, revenueSegment1=9,revenueSegment2=10,revenueOther=11
                                    ,channel=12
            , consumerSegment=13, businessSegment=14, ngoSegment=15 // specific
                                    , relationshipActivity1=16, relationshipActivity2=17, relationshipActivity3=18
                                           , keyActivity=19
                                           , industryRiskPointer_activity=20, industryRiskPointer_industry=21
                                           , vat=22
//range limit 50 in tables 
      }

    public Plan_AttributeRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    internal IQueryable<Plan_Attribute> getQ(Guid plan, PlanAttributeKind such){
      var w=(short)such;
      var r=daContext.Plan_Attributes.Where(x=>x.BusinessPlanId==plan && x.Kind==w).OrderBy(x=>x.OrderValue);
      return r;
      }

    internal List<Plan_Attribute> get(Guid plan, PlanAttributeKind such){
      var r=getQ(plan, such).ToList();
      //var w=(short)such;
      //var r=daContext.Plan_Attributes.Where(x=>x.BusinessPlanId==plan && x.Kind==w).OrderBy(x=>x.OrderValue).ToList();
      return r;
      }

        internal List<Plan_Attribute> getChannels(Guid planId)
        {
            var l = (short)PlanAttributeKind.channel;
            var r = daContext.Plan_Attributes.Where(x => x.BusinessPlanId == planId && x.Kind == l).OrderBy(x => x.Kind).ThenBy(x => x.OrderValue).ToList();
            return r;
        }

    internal List<Plan_Attribute> getRevenues(Guid planId)
        {
            var l = (short)PlanAttributeKind.revenueSegment1;
            var h = (short)PlanAttributeKind.revenueOther;
            var r = daContext.Plan_Attributes.Where(x => x.BusinessPlanId == planId && x.Kind >= l && x.Kind <= h).OrderBy(x => x.Kind).ThenBy(x => x.OrderValue).ToList();
            return r;
        }

        internal List<Plan_Attribute> getCosts(Guid planId) {
      var l=(short)PlanAttributeKind.fixedCost;   
      var h=(short)PlanAttributeKind.variableCost;
      var r=daContext.Plan_Attributes.Where(x=>x.BusinessPlanId==planId && x.Kind>=l && x.Kind<=h).OrderBy(x => x.Kind).ThenBy(x=>x.OrderValue).ToList();
      return r;
      }
    internal List<Plan_Attribute> getPartners(Guid planId) {
      var l=(short)PlanAttributeKind.keyDistributor;
      var h=(short)PlanAttributeKind.otherKeyPartner;
      var r=daContext.Plan_Attributes.Where(x=>x.BusinessPlanId==planId && x.Kind>=l && x.Kind<=h).OrderBy(x=>x.Kind).ThenBy(x=>x.OrderValue).ToList();
      return r;
      }

    internal List<Plan_Attribute> getProducts(Guid planId) {
      var l=(short)PlanAttributeKind.product;
      var r=daContext.Plan_Attributes.Where(x=>x.BusinessPlanId==planId && x.Kind==l).OrderBy(x=>x.Kind).ThenBy(x=>x.OrderValue).ToList();
      return r;
      }

    public List<Plan_Attribute> get(Guid plan){
      var r=daContext.Plan_Attributes.Where(x=>x.BusinessPlanId==plan).ToList();
      return r;
      }

    public List<Plan_Attribute> getSwots(Guid plan){ return get(plan, PlanAttributeKind.swot); }

    internal static void DeleteAttribute(BLontext context, Guid resource, PlanAttributeKind? kindRequired=null, Action<Plan_Attribute, Plan_AttributeRepository> cascade=null) {
      using(var tr=new Transactioner(context)){
        var aRepo=new Plan_AttributeRepository(context, tr.Context);
        var o=aRepo.byId(resource); 
        if(kindRequired!=null && o.Kind!=(short)kindRequired.Value)
          throw new Exception("wrong attribute kind");
        var plan=new BusinessPlansRepository(context).GetPlanForUpdate(context.userGuid, o.BusinessPlanId); // only to validate rights on plan
        if(cascade!=null)
          cascade(o, aRepo);
        aRepo.Delete(o);
        tr.Commit();
        }
      }

    public List<Plan_Attribute> getResources(Guid plan){ return get(plan, PlanAttributeKind.keyResource); }

    public void Delete(Plan_Attribute me) {
      daContext.Plan_Attributes.Remove(me);
      daContext.SaveChanges();
      }

    public void Save(Plan_Attribute olduks) {
      daContext.SaveChanges();
      }

    internal Plan_Attribute byId(Guid attribute_id, Guid? business_plan_idForValidate=null) {
      var r=daContext.Plan_Attributes.Where(x=>x.Id==attribute_id).FirstOrDefault();
      if(business_plan_idForValidate!=null && r.BusinessPlanId!=business_plan_idForValidate)
       throw new Exception("wrong plan as attribute owner");
      return r;
      }

    public Plan_Attribute create(Plan_Attribute me) {
      if(me.Id.ToString()==new Guid().ToString())
        me.Id=Guid.NewGuid();
      daContext.Plan_Attributes.Add(me);
      daContext.SaveChanges();
      return me;
      }

    internal short generateAtrrOrder(Guid business_plan_id) {
      short w=0;
      var l=get(business_plan_id);
      if(l.Count>0)
        w=l.Max(x=>x.OrderValue);
      return ++w;
      }

    protected override object[] getAll4snap() { return daContext.Plan_Attributes.ToArray(); }

    protected override string myTable => "Plan_Attributes";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.Plan_Attribute, Guid>(daContext.Plan_Attributes, json, overwrite, oldDeleted, generateInits);
      }

    internal static void DeleteProduct(BLontext context, Guid resource, bool cascade=false) {
      DeleteAttribute(context, resource, PlanAttributeKind.product, cascade?ProductCascadeDeleteHard:ProductCascadeDeleteCautious);
      }


    private static void ProductCascadeDeleteCautious(Plan_Attribute me, Plan_AttributeRepository repo) { // the context contains started transaction
      ProductCascadeDelete(me, repo, false);
      }

    private static void ProductCascadeDeleteHard(Plan_Attribute me, Plan_AttributeRepository repo) { // the context contains started transaction
      ProductCascadeDelete(me, repo, true);
      }

    private static void ProductCascadeDelete(Plan_Attribute me, Plan_AttributeRepository repo, bool hard) { // the context contains started transaction
      var ctx=repo.daContext;
      var uRepo=new UniversalAttributeRepository(repo.blContext, ctx);
      var kas=uRepo.byMasters(new List<Guid?>(){ me.Id }).Where(x=>x.Kind==(short)PlanAttributeKind.keyActivity).ToList();
      var chs = repo.getChannels(me.BusinessPlanId).Select(x=> new ChannelBL(x,true)).Where(x=>x.e.product_id.Contains(me.Id)).ToList();
      
      if(kas.Count>0||chs.Count>0){
        if(hard){
          foreach(var o in kas)
            ctx.UniversalAttributes.Remove(o);
          foreach (var ch in chs)
          {
            ch.e.product_id.Remove(me.Id);               
            ch.completeSet(ch.id, repo);
            if (ch.e.product_id.Count == 0)
                ctx.Plan_Attributes.Remove(repo.byId(ch.id));
          }        
          ctx.SaveChanges();
         } else breaK();
        }
      }

    private static void breaK() {
      throw new Exception("Dependants present");
      }
    }
    
  }
