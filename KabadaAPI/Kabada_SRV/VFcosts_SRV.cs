using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.Plan_AttributeRepository;

namespace Kabada {
  partial class VFcosts {
    internal void read(BLontext context, Guid planId) {
      var ctx=context;
      var pl=new BusinessPlansRepository(ctx).getRO(planId); // GetPlan(planId, context.userGuid);
      is_fixed_variable_completed=pl.IsFixedVariableCompleted;
      
      var atri= new Plan_AttributeRepository(ctx).getCosts(planId);
      if(atri.Count<1)
        return;

      var tRepo=new TexterRepository(ctx);
      var cati=tRepo.getCostCategories().ToDictionary(x=>x.Id);
      var typi=tRepo.getCostTypes().ToDictionary(x=>x.Id);

      @fixed=make(PlanAttributeKind.fixedCost, cati, typi, atri);
      variable=make(PlanAttributeKind.variableCost, cati, typi, atri);
       }

    private List<CategorizedCosts> make(PlanAttributeKind kind, Dictionary<Guid, KabadaAPIdao.Texter> cati, Dictionary<Guid, KabadaAPIdao.Texter> typi, List<KabadaAPIdao.Plan_Attribute> atri) {
      var subl=atri.Where(x=>x.Kind==(short)kind).ToList();
      if(subl.Count<1)
        return null;
      var r=new List<CategorizedCosts>();
      var kapa=subl.GroupBy(x=>cati[typi[x.TexterId].MasterId.Value]).ToDictionary(g=>g.Key, g=>g.ToList());
      foreach(var k in kapa.Keys){
        var l1=new CategorizedCosts(){ category_id=k.Id, category_title=k.Value, types=new List<TypedCost>()};
        r.Add(l1);
        foreach(var x in kapa[k]){
          var l2=new TypedCost(){ cost_item_id=x.Id, type_id=x.TexterId, type_title=typi[x.TexterId].Value };
          l1.types.Add(l2);
          var y=new CostBL(x);
          l2.vat=y.e.vat;
          l2.price=y.e.price;
          l2.first_expenses=y.e.first_expenses;
          l2.monthly_expenses=y.e.monthly_expenses;
          l2.type_name=y.e.name;
          }
        }
      return r;
      }
    }
  }
