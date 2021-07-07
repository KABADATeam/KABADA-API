using KabadaAPI;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class CostCategory {
    internal void fill(Tertex tvo) {
      var incomingO=tvo.me;
      category_id=incomingO.Id;
      category_title=incomingO.Value;
      description = incomingO.LongValue; //EGO: get description for category
      if(tvo.children.Count<1)
        return; // do not create containers for "Other"
      types=new List<CostType>();

      var tp=(short)EnumTexterKind.costType;

      // process types
      var c1=tvo.children.Where(x=>x.me.Kind==tp).ToList();
      foreach(var o in c1){
        var t=new CostType();
        types.Add(t);
        t.type_id = o.me.Id;
        t.type_title = o.me.Value;
      }
      }
    }
  }
