﻿using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KabadaAPI {
  public class SharedPlanRepository: BaseRepository {
    public SharedPlanRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

    private DbSet<SharedPlan> q0 { get { return daContext.SharedPlans; }}

    internal void add(SharedPlan sharedPlan) {
      if(daContext.SharedPlans.Where(x=>x.BusinessPlanId==sharedPlan.BusinessPlanId && x.UserId==sharedPlan.UserId).Count()>0)
        throw new Exception("duplicates not allowed");
      daContext.SharedPlans.Add(sharedPlan);
      daContext.SaveChanges();
      }

    internal List<Guid> members(Guid planId) {
      var r=q0.Where(x=>x.BusinessPlanId==planId).Select(x=>x.UserId).ToList();
      return r;
      }

    protected override object[] getAll4snap() { return daContext.SharedPlans.ToArray(); }

    protected override string myTable => "SharedPlans";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.SharedPlan, Guid>(daContext.SharedPlans, json, overwrite, oldDeleted, generateInits);
      }

    internal void deleteMember(Deleter resource, Guid uGuid) {
      new BusinessPlansRepository(blContext).GetPlanForUpdate(uGuid, resource.master); // to validate modify rights
      var o=q0.Where(x=>x.BusinessPlanId==resource.master && x.UserId==resource.part).FirstOrDefault();
      if(o==null)
        throw new Exception("missing member");
      q0.Remove(o);
      daContext.SaveChanges();
      }

    //protected override bool loadData(string json, bool overwrite) {
    //  var o=Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.SharedPlan>(json);
    //  daContext.SharedPlans.Add(o);
    //  return true;
    //  }
    }
  }
