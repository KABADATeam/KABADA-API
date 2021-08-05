using KabadaAPI;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class CustomerSegmentsCodifiers {
    private List<Codifier> extract(EnumTexterKind kind, Dictionary<short , List<KabadaAPIdao.Texter>> fullSet){
      List<KabadaAPIdao.Texter> w=null;
      if(fullSet.TryGetValue((short)kind, out w)){
        var r=w.Select(x=> new Codifier(){ id=x.Id, title=x.Value}).ToList();
        if(r.Count>0)
          return r;
        }
      return null;
      }

    internal void read(BLontext context) {
      var codi=new TexterRepository(context).getCustomerSegmentsCodifiersGrouped();
      age_groups=extract(EnumTexterKind.age_group, codi);
      education_types=extract(EnumTexterKind.education, codi);
      income_types=extract(EnumTexterKind.income, codi);
      geographic_locations=extract(EnumTexterKind.geographic_location, codi);
      business_types=extract(EnumTexterKind.industry, codi);
      company_sizes=extract(EnumTexterKind.company_size, codi);
      ngo_types=extract(EnumTexterKind.public_bodies_ngo, codi);
      gender_types=extract(EnumTexterKind.gender, codi);
      }
    }
  }
