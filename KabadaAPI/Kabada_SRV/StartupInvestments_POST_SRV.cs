﻿using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class StartupInvestments_POST {
    internal void perform(BLontext context) {
      validate();
      using(var tr=new Transactioner(context)){
        var ctx=tr.Context;
        var p=new BusinessPlanBL(new BusinessPlansRepository(context, ctx).getRW(business_plan_id), true);
        var t=p.e.startup;
        t.set(this, true);
        //t.grace_period=grace_period;
        //t.interest_rate=interest_rate;
        //t.loan_amount=loan_amount;
        //t.own_money=own_money;
        //t.payment_period=payment_period;
        //t.period=period;
        //t.total_investments=total_investments;
        //t.investment_amount=investment_amount;
        //t.own_assets=own_assets;
        //t.vat_payer=vat_payer;
        //t.working_capital_amount=working_capital_amount;
        //t.startup_own_money=startup_own_money;
        //t.startup_loan_amount=startup_loan_amount;
        //t.grace_period_short=grace_period_short;
        //t.interest_rate_short=interest_rate_short;
        //t.payment_period_short=payment_period_short;
        //if(t.period!=null && t.period!=12 && t.period!=24)
        //  throw new Exception($"Invalid period specified '{period}'");
        //if(t.payment_period!=null){
        //  var w=(t.payment_period / 6)*6;
        //  if(w!=t.payment_period || w<6 || w>120)
        //    throw new Exception($"Invalid payment_period specified '{payment_period}'");
        //  }
        p.e.working_capitals=working_capitals;
        p.unload();
        var kri=new Plan_AttributeRepository(context, ctx).getResources(business_plan_id).ToDictionary(x=>x.Id);
       // fill(kri, physical_assets);
        //  fill(kri, working_capitals); the contents drastically changed
        ctx.SaveChanges();
        tr.Commit();
        }
      }

    private void fill(Dictionary<Guid, KabadaAPIdao.Plan_Attribute> kri, List<AssetPosterElement> assets) {
      if(assets==null)
        return;
      foreach(var x in assets){
        var upo=new KeyResourceBL(kri[x.resource_id], true);
        upo.e.vat=x.vat;
        upo.e.amount=x.amount;
        upo.unload();
        }
      }
    }
  }
