using KabadaAPIdao;
using System;
using System.Collections.Generic;
using static KabadaAPI.DbSettingRepository;

namespace KabadaAPI {
  partial class UsersRepository {
    private List<Func<Transactioner, bool>> initUpdates { get {
      return new List<Func<Transactioner, bool>>(){
//===============================1========================================//
        u_0 };
//=======================================================================//
      }}

    //===============================2========================================//
    private bool u_0(Transactioner tr){ // only to trigger creation of the DbSetting for level
      return true;
      }








//=======================================================================//

    protected override void expandInit() {
      var starter=0;
      var old=new DbSettingRepository(blContext).byId(EnumDbSettings.initialDataSetLevel);
      if(old!=null)
        starter=int.Parse(old.Value);
      var acti=initUpdates;
      var l=acti.Count;
      for(var i=starter; i<l; i++){
        using(var tr=new Transactioner(blContext)){
          if(!acti[i](tr))
            throw new Exception($"Initials setting failed in the step {i}.");
          var v=(i+1).ToString();
          var ctx=tr.Context;
          var sRepo=new DbSettingRepository(blContext, ctx);
          var o=sRepo.byId(EnumDbSettings.initialDataSetLevel);
          if(o==null){
            sRepo.add(EnumDbSettings.initialDataSetLevel, v);
           } else {
              o.Value=v;
              ctx.SaveChanges();
              }
          tr.Commit();
          }
        }
      }
    }
  }
