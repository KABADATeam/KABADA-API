using KabadaAPI;
using KabadaAPIdao;
using System;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class PlanSwotLocalSinglePoster {       

    internal Guid? Save(BLontext context) {            
            var update = new PlanSwotUpdate() {business_plan_id = business_plan_id};    
            if (kind > 0) return update.Save(context,swot,EnumTexterKind.oportunity_local);           
            else return update.Save(context, swot, EnumTexterKind.strength_local);            
     }
    
    }
  }
