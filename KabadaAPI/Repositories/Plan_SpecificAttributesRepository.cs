using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class Plan_SpecificAttributesRepository : BaseRepository {
    public Plan_SpecificAttributesRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}
    public Plan_SpecificAttributesRepository() {}

    protected List<Plan_SpecificAttribute> get(Guid plan, PlanAttributeKind such){
      var w=(short)such;
      var r=daContext.Plan_SpecificAttributes.Where(x=>x.BusinessPlanId==plan && x.Kind==w).OrderBy(x=>x.OrderValue).ToList();
      return r;
      }

    internal Plan_SpecificAttribute personalChar(Guid planId) {
      var t=get(planId, PlanAttributeKind.personalCharacteristics);
      if(t.Count>0)
        return t[0];
      return null;
      }

    internal List<Plan_SpecificAttribute> getSegments(Guid planId) {
      var l=(short)PlanAttributeKind.consumerSegment;
      var h=(short)PlanAttributeKind.ngoSegment;
      var r=daContext.Plan_SpecificAttributes.Where(x=>x.BusinessPlanId==planId && x.Kind>=l && x.Kind<=h).OrderBy(x=>x.Kind).ThenBy(x=>x.OrderValue).ToList();
      return r;
      }

    internal Plan_SpecificAttribute byId(Guid attribute_id, Guid? business_plan_idForValidate=null, short? kindForValidate=null) {
      var r=daContext.Plan_SpecificAttributes.Where(x=>x.Id==attribute_id).FirstOrDefault();
      if(business_plan_idForValidate!=null && r.BusinessPlanId!=business_plan_idForValidate)
       throw new Exception("wrong plan as attribute owner");
      if(kindForValidate!=null && r.Kind!=kindForValidate)
       throw new Exception("wrong attribute kind");
      return r;
      }

    public void Delete(Plan_SpecificAttribute me) {
      daContext.Plan_SpecificAttributes.Remove(me);
      daContext.SaveChanges();
      }

    internal static void DeleteAttribute(BLontext context, Guid resource, PlanAttributeKind? kindRequired=null) {
      using(var tr=new Transactioner(context)){
        var aRepo=new Plan_SpecificAttributesRepository(context, tr.Context);
        var o=aRepo.byId(resource); 
        if(kindRequired!=null && o.Kind!=(short)kindRequired.Value)
          throw new Exception("wrong attribute kind");
        //var plan=new BusinessPlansRepository(context).GetPlanForUpdate(context.userGuid, o.BusinessPlanId); // only to validate rights on plan
        var plan0=new BusinessPlansRepository(context).validateRW(context.userGuid, o.BusinessPlanId);
        aRepo.Delete(o);
        tr.Commit();
        }
      }

    public void Save(Plan_SpecificAttribute olduks) {
      daContext.SaveChanges();
      }

    public List<Plan_SpecificAttribute> get(Guid plan){
      var r=daContext.Plan_SpecificAttributes.Where(x=>x.BusinessPlanId==plan).OrderBy(x=>x.OrderValue).ToList();
      return r;
      }

    internal short generateAtrrOrder(Guid business_plan_id) {
      short w=0;
      var l=get(business_plan_id);
      if(l.Count>0)
        w=l.Max(x=>x.OrderValue);
      return ++w;
      }

    public Plan_SpecificAttribute create(Plan_SpecificAttribute me) {
      if(me.Id.ToString()==new Guid().ToString())
        me.Id=Guid.NewGuid();
      daContext.Plan_SpecificAttributes.Add(me);
      daContext.SaveChanges();
      return me;
      }

    protected override object[] getAll4snap() { return daContext.Plan_SpecificAttributes.ToArray(); }
    protected override string myTable => "Plan_SpecificAttributes";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.Plan_SpecificAttribute, Guid>(daContext.Plan_SpecificAttributes, json, overwrite, oldDeleted, generateInits);
      }

    protected override Guid? guid(string json) {
      var o = Newtonsoft.Json.JsonConvert.DeserializeObject<Plan_SpecificAttribute>(json);
      return o.Id;
      }

    internal override void import(Guid newId, string json, UnloadSetImport unloadSetImport) {
      var o = Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.Plan_SpecificAttribute>(json);
      o.Id=newId;
      o.BusinessPlanId=upis(o.BusinessPlanId, unloadSetImport);
      daContext.Add(o);
      }
    }
  }
