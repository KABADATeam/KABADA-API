using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class NgoSegmentBL : CustomerSegmentBL {
    private const short KIND=(short)PlanAttributeKind.ngoSegment;

    public NgoSegmentBL() : base(KIND) {}
    public NgoSegmentBL(KabadaAPIdao.Plan_SpecificAttribute old, bool forUpdate=false) : base(KIND, old, forUpdate){}
    public NgoSegmentBL(Guid byId, Plan_SpecificAttributesRepository repo) : base(byId, repo, KIND) {}

    public static NgoSegmentBL Make(Guid? id, Plan_SpecificAttributesRepository repo){
      if(id==null)
        return new NgoSegmentBL();
       else
        return new NgoSegmentBL(id.Value, repo);
      }
    }
  }
