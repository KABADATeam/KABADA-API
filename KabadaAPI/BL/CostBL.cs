using Kabada;
using System;
using System.Collections.Generic;
using static KabadaAPI.Plan_AttributeRepository;

namespace KabadaAPI {
  public class CostBL : BAsePlan_AttributeTypedBL<CostElementBL> { // Plan_AttributeBL<CostElementBL> {
    public static readonly List<short> KINDs=new List<short>(){ (short)PlanAttributeKind.fixedCost, (short)PlanAttributeKind.variableCost};

    public CostBL(short kind, Guid plan, Guid texter) : base(kind, plan, texter) {}
    public CostBL(PlanAttributeKind kind, Guid plan, Guid texter) : this((short)kind, plan, texter) {}
    public CostBL(KabadaAPIdao.Plan_Attribute old, bool forUpdate=false, Guid? planForValidate=null) : base(old, forUpdate, planForValidate, kindsForValidate: KINDs){}
    public CostBL(Guid byId, Plan_AttributeRepository repo, Guid? planForValidate=null) : base(byId, repo, true, planForValidate, kindsForValidate: KINDs) {}

    public CashFlowRow myCashFlow;
    public void fillMyCashFlow(short? months){
      if(months==0 || months==null || (e.price==null && e.monthly_expenses==null))
        return;
      myCashFlow=new CashFlowRow("", period: months.Value);
      var n=myCashFlow.monthlyValue.Count-1;
      if(e.monthly_expenses==null){
      var i0=0;
      if(e.first_expenses!=null)
        i0=e.first_expenses.Value;
      for(var i=i0; i<=n; i++)
        myCashFlow.monthlyValue[i]=e.price.Value;
      } else {
       var m=e.monthly_expenses.Count;
       if(m>n)
         m=n;
       for(var i=0; i<m; i++)
         myCashFlow.monthlyValue[i+1]=e.monthly_expenses[i];
       }
      }
    }
  }
