﻿using KabadaAPI;
using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class PlanSwotUpdate {
    Transactioner tr;

    protected TexterRepository tR;
    protected Plan_AttributeRepository paR;

    protected Dictionary<Guid, Texter> inventory;
    protected Dictionary<Guid, Plan_Attribute> oldi;


    internal void Perform(BLontext context, KabadaAPIdao.BusinessPlan plan) {
      inventory=new TexterRepository(context).getSWOTs(business_plan_id).ToDictionary(x=>x.Id);

      using(tr=new Transactioner(context)){
        paR=new Plan_AttributeRepository(context, tr.Context);
        tR=new TexterRepository(context, tr.Context);
        oldi=paR.getSwots(business_plan_id).ToDictionary(x=>x.TexterId);

        perform(this.strengths_weakness, EnumTexterKind.strength_local);
        perform(this.opportunities_threats, EnumTexterKind.oportunity_local);

        tr.Commit();
        }
      }

    private void perform(List<SwotUpdater> todo, EnumTexterKind localKind) {
      if(todo==null || todo.Count<1)
        return;
      var lk=(short)localKind;
      Plan_Attribute olduks=null;
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
           if(o.operation==(short.Parse(olduks.AttrVal)))
             continue; // the same value already present
           if(o.operation<1)
             paR.Delete(olduks);
            else {
             olduks.AttrVal=o.operation.ToString();
             paR.Save(olduks);
             }
         } else {
          if(o.operation>0){
            var nrs=new Plan_Attribute(){ BusinessPlanId=business_plan_id, Kind=(short)Plan_AttributeRepository.PlanAttributeKind.swot, AttrVal=o.operation.ToString(), TexterId=o.id.Value };
            paR.Create(nrs);
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