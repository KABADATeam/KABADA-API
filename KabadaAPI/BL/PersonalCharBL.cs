using Kabada;
using System;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class PersonalCharBL : BAsePlan_SpecificAttributeTypedBL<List<ChoiceElement>> {
    private const short KIND=(short)PlanAttributeKind.personalCharacteristics;

    public PersonalCharBL(Guid plan) : base(KIND, plan) {}
    public PersonalCharBL(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(old, forUpdate, kindForValidate:KIND){}
    public PersonalCharBL(Guid byId, Plan_SpecificAttributesRepository repo, bool forUpdate=false, Guid? planForValidate=null)
                   : base(byId, repo, forUpdate, planForValidate, KIND) {}

    //public static PersonalCharBL Make(Plan_SpecificAttributesRepository repo, Guid plan){
    //  var o=repo.personalChar(plan);
    //  if(o==null)
    //    return new PersonalCharBL(plan);
    //   else
    //    return new PersonalCharBL(o, true);
    //  }
    }
  }
