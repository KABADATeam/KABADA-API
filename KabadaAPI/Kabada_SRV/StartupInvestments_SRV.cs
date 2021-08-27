using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class StartupInvestments {
    protected BLontext ctx;

    protected List<AssetElement> make(List<KeyResourceBL> source){
      if(source==null || source.Count<1)
        return null;
      return source
           .Select(x=>new AssetElement { amount=x.e.amount, resource_id=x.id, vat=x.e.vat, resource_title=x.e.name/*, resource_status=x.e.ow*/}).ToList();
      }

    internal void read(BLontext context, Guid planId) {
      ctx=context;

      var pl=new BusinessPlanBL(new BusinessPlansRepository(ctx).GetPlan(planId, context.userGuid));
      is_business_investments_completed=pl.o.IsBusinessInvestmentsCompleted;
      period=pl.e.startup.period;
      vat_payer=pl.e.startup.vat_payer;
      total_investments=pl.e.startup.total_investments;
      own_money=pl.e.startup.own_money;
      loan_amount=pl.e.startup.loan_amount;
      payment_period=pl.e.startup.payment_period;
      interest_rate=pl.e.startup.interest_rate;
      grace_period=pl.e.startup.grace_period;
      
      var atri= new Plan_AttributeRepository(ctx).getResources(planId).Select(x=>new KeyResourceBL(x)).ToList();
      if(atri.Count<1)
        return;
      var tRepo=new TexterRepository(ctx);
      var HID=new Guid("63CEE727-8378-4603-8B0B-839751DFEED1");
      var typi=tRepo.getKeyResourceTypes(HID).Where(x=>x.MasterId!=null).ToDictionary(x=>x.Id, x=>false);

      var lh=new List<KeyResourceBL>();
      var lo=new List<KeyResourceBL>();
      foreach(var a in atri){
        if(typi.ContainsKey(a.texterId))
          lh.Add(a);
         else
          lo.Add(a);
        }
      physical_assets=make(lo);
      working_capital=make(lh);
      }
    }
  }
