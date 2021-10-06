using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  partial class TexterRepository {
    public static List<Texter> CustomerSegmentsCodifiers(){
      var r=age_group();
      r.AddRange(income());
      r.AddRange(education());
      r.AddRange(geographic_location());
      r.AddRange(company_size());
      r.AddRange(industry());
      r.AddRange(public_bodies_ngo());
      r.AddRange(gender());
      return r;
      }

    private static List<Texter> age_group(){
      return Codifiers(EnumTexterKind.age_group,
        "Under 12", "12 - 17", "18 - 24", "25 - 34", "35 - 64", "65 - 74", "75 years or older", "All age groups"
        );
     }

    private static List<Texter> income(){
      return Codifiers(EnumTexterKind.income,
        "Low", "Medium", "High"
        );
     }

    private DbSet<Texter> q0 { get { return daContext.Texters; }}

    internal Guid set(short kind, string value) {
      var r=q0.Where(x=>x.Kind==kind && x.Value==value).FirstOrDefault();
      if(r==null){
        r=new Texter(){Id=Guid.NewGuid(), Kind=kind, Value=value };
        q0.Add(r);
        daContext.SaveChanges();
        }
      return r.Id;
      }
    internal Guid set(Guid master, short kind, string value){
        var r = q0.Where(x => x.Kind == kind && x.MasterId == master && x.Value == value).FirstOrDefault();
        if (r == null) {
            r = new Texter() { Id = Guid.NewGuid(), Kind = kind, Value = value, MasterId = master };
            q0.Add(r);
            daContext.SaveChanges();
        }
        return r.Id;
    }
    internal Guid set(Guid master, short kind, string value, string longvalue=null, short ordervalue = 1) {
    var r=q0.Where(x=>x.Kind==kind && x.MasterId==master && x.Value==value).FirstOrDefault();
    if(r==null){
    r=new Texter(){Id=Guid.NewGuid(), Kind=kind, Value=value, MasterId=master, LongValue=longvalue, OrderValue=ordervalue };
    q0.Add(r);
    daContext.SaveChanges();
    }
    return r.Id;
    }

    private static List<Texter> education(){
      return Codifiers(EnumTexterKind.education,
        "Primary", "Secondary", "Higher education"
        );
     }

    private static List<Texter> geographic_location(){
      return Codifiers(EnumTexterKind.geographic_location,
       	"Domestic", "Domestic Urban", "Domestic Rural", "Foreign", "Foreign Urban", "Foreign Rural","Transnational"
        );
     }

    private static List<Texter> company_size(){
      return Codifiers(EnumTexterKind.company_size,
       	"Small", "Medium","Large"
        );
     }

    private static List<Texter> industry(){
      return Codifiers(EnumTexterKind.industry,
       	"Goods", "Services"
        );
     }

    private static List<Texter> public_bodies_ngo(){
      return Codifiers(EnumTexterKind.public_bodies_ngo,
       	"International Organisations", "National Government", "Muncipality", "Non-Government organisations"
        );
     }

    private static List<Texter> gender(){
      return Codifiers(EnumTexterKind.gender,
       	"male", "female"
        );
     }

    internal int deleteIRs(List<Guid> excludeList) {
      var k=(short)EnumTexterKind.industryRisks;
      var deeli=q0.Where(x=>x.Kind==k && !excludeList.Contains(x.Id)).ToList();
      foreach(var o in deeli)
        q0.Remove(o);
      daContext.SaveChanges();
      return deeli.Count;
      }
    }
  }
