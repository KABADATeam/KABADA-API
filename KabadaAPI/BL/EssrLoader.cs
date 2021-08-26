using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class EssrLoader : UAloader {
     public EssrLoader() { KIND=EssrBL.KIND; }

    protected Dictionary<string, Country> countries;

    protected override void loadInit(string fileWithFullPath, BLontext blContext) {
      countries=new CountryRepository(blContext).GetCountries().ToDictionary(x=>x.ShortCode);
      }

    protected Dictionary<string, short> years;

    protected void inityears(){
      if(years!=null)
        return;
      years=rdr.GetFieldHeaders().Select(x=>x.Trim()).Where(x=>x.Length==4 && x.All(c => c >= '0' && c <= '9')).ToDictionary(x=>x, x=>short.Parse(x));
      if(years.Count<1)
        throw new Exception("The header row does not contain any year");
      }

    protected override object storeRow() {
      inityears();
      if(years.Count<1)
        return null;

      var cnID=yMstring("Country code");
      Country cn=null;
      if(!countries.TryGetValue(cnID, out cn))
        return null; // not our country

      UniversalAttribute my=null;
      EssrBL r=null;

      Guid? aste=null;
      if(oldies.TryGetValue(cn.Id, out my)){
        r=new EssrBL(my, true);
        aste=r.id;
        }
       else {
        r=new EssrBL(cn.Id);
        }

      foreach(var y in years){
        var v=rdm(y.Key);
        if(v==null)
          continue;
        r.e[y.Value]=v.Value;
        }

      r.validate();
      r.completeSet(aste, uRepo);
      goodRecords++;
      return r;
      }
   
    }
  }
