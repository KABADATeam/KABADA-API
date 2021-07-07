using KabadaAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class CostCategories {
    internal void read(BLontext context) {
      fixed_categories=new List<CostCategory>();
variable_categories= new List<CostCategory>();
            var tRepo=new TexterRepository(context);
      var txi=tRepo.getCostMeta(); // all required texters
      var vxi=Tertex.CreateMasterTree(txi);

      foreach(var o in vxi.children){
        var t=new CostCategory();
        //categories.Add(t);
        if(o.me.Kind== (short)EnumTexterKind.fixedCostCategory) fixed_categories.Add(t);
        else variable_categories.Add(t);
        t.fill(o);
        }
      }
    }
  }
