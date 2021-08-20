using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public abstract class CustomerSegmentBL : BAsePlan_SpecificAttributeTypedBL<CustomerSegmentElementBL> { //Plan_SpecificAttributeBL<CustomerSegmentElementBL> {
    public CustomerSegmentBL(short kind) : base(kind) {}
    public CustomerSegmentBL(short kindForTest, KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(old, forUpdate, kindForValidate: kindForTest){}
    public CustomerSegmentBL(Guid byId, Plan_SpecificAttributesRepository repo, short? kindForValidate=null) : base(byId, repo, true, kindForValidate: kindForValidate) {}

    //public CustomerSegmentBL Make(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false){
    //  var ek=(PlanAttributeKind)old.Kind;
    //  switch(ek){
    //    case PlanAttributeKind.consumerSegment: return new ConsumerSegmentBL(old, forUpdate);
    //    case PlanAttributeKind.businessSegment: return new BusinessSegmentBL(old, forUpdate);
    //    case PlanAttributeKind.ngoSegment: return new NgoSegmentBL(old, forUpdate);
    //    default: throw new Exception($"Invalid kid='{ek.ToString()}'");
    //    }
    //  }

    public static CustomerSegmentBL Make(short ek, Guid? id, Plan_SpecificAttributesRepository repo){
      switch((PlanAttributeKind)ek){
        case PlanAttributeKind.consumerSegment: return ConsumerSegmentBL.Make(id, repo);
        case PlanAttributeKind.businessSegment: return BusinessSegmentBL.Make(id, repo);
        case PlanAttributeKind.ngoSegment:      return NgoSegmentBL.Make(id, repo);
        default: throw new Exception($"Invalid kind='{ek.ToString()}'");
        }
      }
    }
  }
