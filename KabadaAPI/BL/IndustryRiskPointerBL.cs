using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class IndustryRiskPointerBL : BAseUniversalAttributeTypedBL<object> {
    public IndustryRiskPointerBL(short kind) : base(kind) {}
    public IndustryRiskPointerBL(short kindForTest, KabadaAPIdao.UniversalAttribute old, bool forUpdate=false) : base(old, forUpdate, kindForValidate: kindForTest){}
    public IndustryRiskPointerBL(Guid byId, UniversalAttributeRepository repo, bool forUpdate=false, short? kindForValidate=null)
                                  : base(byId, repo, forUpdate, kindForValidate: kindForValidate) {}


    public static IndustryRiskPointerBL Make(short ek, Guid? id, UniversalAttributeRepository repo){
      switch((PlanAttributeKind)ek){
        case PlanAttributeKind.industryRiskPointer_activity: return IndustryRiskPointer_activity.Make(id, repo);
        //case PlanAttributeKind.businessSegment: return BusinessSegmentBL.Make(id, repo);
        //case PlanAttributeKind.ngoSegment:      return NgoSegmentBL.Make(id, repo);
        default: throw new Exception($"Invalid kind='{ek.ToString()}'");
        }
      }
    }
  }
