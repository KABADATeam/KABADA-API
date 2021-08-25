using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public abstract class UAloader : CsvLoader {
    protected short KIND;
    protected UniversalAttributeRepository uRepo;
    protected int goodRecords;
    protected Dictionary<Guid, UniversalAttribute> oldies;

    protected decimal? rdm(string key){
      var w=yOstring(key);
      if(string.IsNullOrWhiteSpace(w) || w.Trim()=="-")
        return null;
      return yOdec(key);
      }

    protected virtual void loadInit(string fileWithFullPath, BLontext blContext){}

    public bool load(string fileWithFullPath, BLontext blContext){
      goodRecords=0;
      loadInit(fileWithFullPath, blContext);
      using(var tr=new Transactioner(blContext)){
        uRepo=new UniversalAttributeRepository(blContext, tr.Context);
        oldies=uRepo.byKind(KIND).ToDictionary(x=>x.MasterId.Value);
        loadInternal(fileWithFullPath);
        if(errors<1 && goodRecords>0){
          tr.Commit();
          return true;
          }
        }
      return false;
      }
    }
  }
