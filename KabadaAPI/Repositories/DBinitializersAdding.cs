using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.DbSettingRepository;
using static KabadaAPI.TexterRepository;

namespace KabadaAPI {
  partial class UsersRepository {
    private List<Func<Transactioner, bool>> initUpdates { get {
      return new List<Func<Transactioner, bool>>(){
//===============================1========================================//
        u_0, u_1, u_2, u_3, u_4, u_5, u_6 };
//=======================================================================//
      }}

    //===============================2========================================//
    private bool u_0(Transactioner tr){ // only to trigger creation of the DbSetting for level
      return true;
      }

    private void u_1helper(TexterRepository tx, string type, params string[] subtype){
      var m=tx.set((short)EnumTexterKind.activityType, type);
      foreach(var t in subtype)
        tx.set(m, (short)EnumTexterKind.activitySubtype, t);
      }

    private bool u_1(Transactioner tr){ // activities types
      var ctx=tr.Context;
      var tx=new TexterRepository(blContext, ctx);
      u_1helper(tx, "Production", "Logistics", "Operations", "Marketing", "Services", "R & D");
      u_1helper(tx, "Problem solving", "Knowledge management", "Recruitment", "Continous training", "Marketing");
      u_1helper(tx, "Platform/Network", "R & D", "Platform management", "Service provisioning", "Marketing");
      return true;
      }

    private bool u_2(Transactioner tr){ // Activities.ContainerActivity filling
      var ctx=tr.Context;
      var tx=new IndustryActivityRepository(blContext, ctx);
      tx.initContainerActivity();
      return true;
      }
        
    private bool importLoader(DAcontext da=null){
      //var t = new IndustryRisksManager(blContext, da);
      //t.process(true); //.processInits();
      LoaderManager.Import(blContext, true);
      return true;
      }

        private bool u_3(Transactioner tr)
        { // Activities.ContainerActivity filling
            var ctx = tr.Context;
            return importLoader(ctx);
        }

    private bool u_4(Transactioner tr) {
      var ctx = tr.Context;
      return importLoader(ctx);
      }
    private bool u_5(Transactioner tr)
    {
        var ctx = tr.Context;
        return importLoader(ctx);
    }
        private string u_6setOwnershipType()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Rent", selected=default},
                new Kabada.ResourceOption(){title="Buy", selected=default},
                new Kabada.ResourceOption(){title="Own", selected=default},
            });
        }
        private string u_6setFrequency()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Permanently", selected=default},
                new Kabada.ResourceOption(){title="Time to time", selected=default},
            });
        }
        private bool u_6(Transactioner tr)
        { 
            var ctx = tr.Context;
            var tx = new TexterRepository(blContext, ctx);
            var m = daContext.Texters.Where(x => x.Value.Contains("Intellectual resources")).FirstOrDefault();
            if (m == null) return true;
            var subtypes = daContext.Texters.Where(x => x.MasterId==m.Id&&x.Kind== (short)EnumTexterKind.keyResourceType).ToList();
            foreach (var t in subtypes)
            {
                tx.set(t.Id, (short)EnumTexterKind.keyResourcesSelection, "Ownership type", u_6setOwnershipType(),1);
                tx.set(t.Id, (short)EnumTexterKind.keyResourcesSelection, "Frequency", u_6setFrequency(),2);
            }
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
