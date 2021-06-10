using KabadaAPI.DataSource.Models;
using KabadaAPI.DataSource.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.DataSource.Repositories.TexterRepository;

namespace KabadaAPI.ViewModels {
  partial class PlanSwotUpdate {
    Transactioner tr;

    protected TexterRepository tR;
    protected Plan_SWOTRepository psR;

    protected Dictionary<Guid, Texter> inventory;
    protected Dictionary<Guid, Plan_SWOT> oldi;


    internal void Perform(IConfiguration config, ILogger logger, DataSource.Models.BusinessPlan plan) {
      inventory=new TexterRepository(config, logger).get(business_plan_id).ToDictionary(x=>x.Id);

      using(tr=new Transactioner(config, logger)){
        psR=new Plan_SWOTRepository(config, logger, tr.Context);
        tR=new TexterRepository(config, logger, tr.Context);
        oldi=psR.get(business_plan_id).ToDictionary(x=>x.TexterId);

        perform(this.strengths_weakness, EnumTexterKind.strength_local);
        perform(this.opportunities_threats, EnumTexterKind.oportunity_local);

        tr.Commit();
        }
      }

    private void perform(List<SwotUpdater> todo, EnumTexterKind localKind) {
      if(todo==null || todo.Count<1)
        return;
      var lk=(short)localKind;
      Plan_SWOT olduks=null;
      foreach(var o in todo){
        // process Texter
        if(o.id==null){ // new local
          if(string.IsNullOrWhiteSpace(o.name))
            throw new Exception("No name specified for a new local swotter.");
          //if(o.kind_type!=lk)
          //  throw new Exception($"'{o.name}' has invalid kind_type={o.kind_type} (shold be {lk}).");
          if(o.operation==-1)
            throw new Exception($"'{o.name}' create contradicts delete operation.");
          var nlt=new Texter(){ Kind=lk, MasterId=this.business_plan_id, Value=o.name };
          nlt=tR.Create(nlt);
          o.id=nlt.Id;
         } else { // existent
          if(!inventory.ContainsKey(o.id.Value))
            throw new Exception($"A swotter with id '{o.id.Value}' not found.");
          } // existent

        // process resolution
        if(oldi.TryGetValue(o.id.Value, out olduks)){ // was present
           oldi.Remove(olduks.Id);
           if(o.operation==olduks.Kind)
             continue; // the same value already present
           if(o.operation<1)
             psR.Delete(olduks);
            else {
             olduks.Kind=o.operation;
             psR.Save(olduks);
             }
         } else {
          if(o.operation>0){
            var nrs=new Plan_SWOT(){ BusinessPlanId=business_plan_id, Kind=o.operation, TexterId=o.id.Value };
            psR.Create(nrs);
            }
          }

        // perform operation==-1 (remove)
        if(o.operation==-1){//
          var t=tR.getById(o.id.Value);
          if(t.MasterId!=business_plan_id)
            throw new Exception($"Wrong request to delete the Texter {t.Id} not being local to the {business_plan_id}.");
          tR.Delete(t);
          }
        }
      }
    }
  }
