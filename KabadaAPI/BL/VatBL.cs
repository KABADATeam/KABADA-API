using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class VatBL : BAseUniversalAttributeTypedBL<VatElement> {
    public const short KIND=(short)PlanAttributeKind.vat;

    public VatBL(Guid country) : base(KIND, country) { }
    public VatBL(KabadaAPIdao.UniversalAttribute old, bool forUpdate=false) : base(old, forUpdate, KIND){}

    public VatBL(Guid byId, UniversalAttributeRepository repo) : base(byId, repo, true, KIND) {}

    public static VatBL Make(Guid? id, UniversalAttributeRepository repo, Guid country){
      VatBL r;
      if(id==null)
        r=new VatBL(country);
       else
        r=new VatBL(id.Value, repo);
      return r;
      }

    internal void validate() {
      }
    }
  }
