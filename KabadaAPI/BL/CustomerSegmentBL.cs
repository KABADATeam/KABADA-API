using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public abstract class CustomerSegmentBL : Plan_SpecificAttributeBL<CustomerSegmentElementBL> {
    public CustomerSegmentBL(short kind) : base(kind) {}
    public CustomerSegmentBL(short kindForTest, KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(kindForTest, old, forUpdate){}

    public CustomerSegmentBL Make(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false){
      var ek=(PlanAttributeKind)old.Kind;
      switch(ek){
        case PlanAttributeKind.consumerSegment: return new ConsumerSegmentBL(old, forUpdate);
        case PlanAttributeKind.businessSegment: return new BusinessSegmentBL(old, forUpdate);
        case PlanAttributeKind.ngoSegment: return new NgoSegmentBL(old, forUpdate);
        default: throw new Exception($"Invalid kid='{ek.ToString()}'");
        }
      }
    }
  }
