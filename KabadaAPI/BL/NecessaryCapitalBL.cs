using System;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class NecessaryCapitalBL : BAsePlan_SpecificAttributeTypedBL<List<decimal?>> {
    private const short KIND=(short)PlanAttributeKind.necessaryCapital;

    public NecessaryCapitalBL(Guid plan) : base(KIND, plan) {}
    public NecessaryCapitalBL(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(old, forUpdate, kindForValidate:KIND){}
    public NecessaryCapitalBL(Guid byId, Plan_SpecificAttributesRepository repo, bool forUpdate=false, Guid? planForValidate=null)
                   : base(byId, repo, forUpdate, planForValidate, KIND) {}

    public static NecessaryCapitalBL Make(Guid? id, Plan_SpecificAttributesRepository repo, Guid plan){
      if(id==null)
        return new NecessaryCapitalBL(plan);
       else
        return new NecessaryCapitalBL(id.Value, repo, true, plan);
      }
    }
  }
