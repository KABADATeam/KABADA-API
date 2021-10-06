using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class LoanBL : BAsePlan_SpecificAttributeTypedBL<LoanElementBL> {
    private const short KIND=(short)PlanAttributeKind.loan;

    public LoanBL(Guid plan) : base(KIND, plan) {}
    public LoanBL(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(old, forUpdate, kindForValidate:KIND){}
    public LoanBL(Guid byId, Plan_SpecificAttributesRepository repo, bool forUpdate=false, Guid? planForValidate=null)
                   : base(byId, repo, forUpdate, planForValidate, KIND) {}

    public static LoanBL Make(Guid? id, Plan_SpecificAttributesRepository repo, Guid plan){
      if(id==null)
        return new LoanBL(plan);
       else
        return new LoanBL(id.Value, repo, true, plan);
      }
    }
  }
