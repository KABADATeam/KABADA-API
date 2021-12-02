using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class KeyActivityBL : BAseUniversalAttributeTypedBL<KeyActivityElementBL> { // UniversalAttributeBL<KeyActivityElementBL> {
    public const short KIND=(short)PlanAttributeKind.keyActivity;

    public KeyActivityBL(Guid product) : base(KIND, product) {}
    public KeyActivityBL(KabadaAPIdao.UniversalAttribute old, bool forUpdate=false) : base(old, forUpdate, KIND){}

    public KeyActivityBL(Guid byId, UniversalAttributeRepository repo, Guid product) : base(byId, repo, true, KIND) {}

    public static KeyActivityBL Make(Guid? id, UniversalAttributeRepository repo, Guid product, bool skipValidatePlanRights=false){
      KeyActivityBL r;
      if(id==null)
        r=new KeyActivityBL(product);
       else
        r=new KeyActivityBL(id.Value, repo, product);
      if(skipValidatePlanRights==false){
        var p=new ProductBL(r.masterId.Value, new Plan_AttributeRepository(repo.blContext, repo.daContext));
        //new BusinessPlansRepository(repo.blContext, repo.daContext).GetPlanForUpdate(repo.blContext.userGuid, p.businessPlanId);
        new BusinessPlansRepository(repo.blContext, repo.daContext).validateRW(repo.blContext.userGuid, p.businessPlanId);
        }
      return r;
      }
    }
  }
