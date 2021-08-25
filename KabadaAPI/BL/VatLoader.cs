using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class VatLoader : UAloader {
    public VatLoader() { KIND=(short)PlanAttributeKind.vat; }

    protected Dictionary<string, Country> countries;

    protected override void loadInit(string fileWithFullPath, BLontext blContext) {
      countries=new CountryRepository(blContext).GetCountries().ToDictionary(x=>x.ShortCode);
      }

    protected override object storeRow() {
      var cnID=yMstring("Code");
      var cn=countries[cnID];
      UniversalAttribute my=null;
      VatBL r=null;
      Guid? aste=null;
      if(oldies.TryGetValue(cn.Id, out my)){
        r=new VatBL(my, true);
        aste=r.id;
        }
       else {
        r=new VatBL(cn.Id);
        }

      // TODO assign
      r.e.StandardRate=yMdec("Standard Rate");
      r.e.ReducedRates1=rdm("Reduced Rates1");
      r.e.ReducedRates2=rdm("Reduced Rates2");
      r.e.SuperReducedRate=rdm("Super-reduced Rate");

      r.validate();
      r.completeSet(aste, uRepo);
      goodRecords++;
      return r;
      }
    }
  }
