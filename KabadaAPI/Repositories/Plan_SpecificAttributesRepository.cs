﻿using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class Plan_SpecificAttributesRepository : BaseRepository {
    public Plan_SpecificAttributesRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    protected List<Plan_SpecificAttribute> get(Guid plan, PlanAttributeKind such){
      var w=(short)such;
      var r=daContext.Plan_SpecificAttributes.Where(x=>x.BusinessPlanId==plan && x.Kind==w).OrderBy(x=>x.OrderValue).ToList();
      return r;
      }

    internal Plan_SpecificAttribute byId(Guid attribute_id, Guid? business_plan_idForValidate=null) {
      var r=daContext.Plan_SpecificAttributes.Where(x=>x.Id==attribute_id).FirstOrDefault();
      if(business_plan_idForValidate!=null && r.BusinessPlanId!=business_plan_idForValidate)
       throw new Exception("wrong plan as attribute owner");
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
        var plan=new BusinessPlansRepository(context).GetPlanForUpdate(context.userGuid, o.BusinessPlanId); // only to validate rights on plan
        aRepo.Delete(o);
        tr.Commit();
        }
      }
    }
  }
