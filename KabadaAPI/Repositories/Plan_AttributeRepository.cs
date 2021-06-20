﻿using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public class Plan_AttributeRepository : BaseRepository {
    public enum PlanAttributeKind { swot=1, keyResource=2, keyDistributor=3, keySupplier=4, otherKeyPartner=5 }

    public Plan_AttributeRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    protected List<Plan_Attribute> get(Guid plan, PlanAttributeKind such){
      var w=(short)such;
      var r=daContext.Plan_Attributes.Where(x=>x.BusinessPlanId==plan && x.Kind==w).OrderBy(x=>x.OrderValue).ToList();
      return r;
      }

    internal List<Plan_Attribute> getPartners(Guid planId) {
      var l=(short)PlanAttributeKind.keyDistributor;
      var h=(short)PlanAttributeKind.otherKeyPartner;
      var r=daContext.Plan_Attributes.Where(x=>x.BusinessPlanId==planId && x.Kind>=l && x.Kind<=h).OrderBy(x=>x.Kind).ThenBy(x=>x.OrderValue).ToList();
      return r;
      }

    protected List<Plan_Attribute> get(Guid plan){
      var r=daContext.Plan_Attributes.Where(x=>x.BusinessPlanId==plan).OrderBy(x=>x.OrderValue).ToList();
      return r;
      }

    public List<Plan_Attribute> getSwots(Guid plan){ return get(plan, PlanAttributeKind.swot); }

    internal static void DeleteAttribute(BLontext context, Guid resource, PlanAttributeKind? kindRequired=null) {
      using(var tr=new Transactioner(context)){
        var aRepo=new Plan_AttributeRepository(context, tr.Context);
        var o=aRepo.byId(resource); 
        if(kindRequired!=null && o.Kind!=(short)kindRequired.Value)
          throw new Exception("wrong attribute kind");
        var plan=new BusinessPlansRepository(context).GetPlanForUpdate(context.userGuid, o.BusinessPlanId); // only to validate rights on plan
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

    public Plan_Attribute Create(Plan_Attribute me) {
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
    }
  }