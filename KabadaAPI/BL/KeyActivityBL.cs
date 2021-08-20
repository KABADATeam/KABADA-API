using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class KeyActivityBL : BAseUniversalAttributeTypedBL<KeyActivityElementBL> { // UniversalAttributeBL<KeyActivityElementBL> {
    public const short KIND=(short)PlanAttributeKind.activity;

    public KeyActivityBL() : base(KIND) {}
    public KeyActivityBL(KabadaAPIdao.UniversalAttribute old, bool forUpdate=false) : base(old, forUpdate, KIND){}

    public KeyActivityBL(Guid byId, UniversalAttributeRepository repo) : base(byId, repo, true, KIND) {}

    public static KeyActivityBL Make(Guid? id, UniversalAttributeRepository repo){
      if(id==null)
        return new KeyActivityBL();
       else
        return new KeyActivityBL(id.Value, repo);
      }
    }
  }
