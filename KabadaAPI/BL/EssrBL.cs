using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class EssrBL : BAseUniversalAttributeTypedBL<EssrElement> {
    public const short KIND=(short)PlanAttributeKind.essr;

    public EssrBL(Guid country) : base(KIND, country) { }
    public EssrBL(KabadaAPIdao.UniversalAttribute old, bool forUpdate=false) : base(old, forUpdate, KIND){}

    public EssrBL(Guid byId, UniversalAttributeRepository repo) : base(byId, repo, true, KIND) {}

    public static EssrBL Make(Guid? id, UniversalAttributeRepository repo, Guid country){
      EssrBL r;
      if(id==null)
        r=new EssrBL(country);
       else
        r=new EssrBL(id.Value, repo);
      return r;
      }

    internal void validate() {
      }
    }
  }
