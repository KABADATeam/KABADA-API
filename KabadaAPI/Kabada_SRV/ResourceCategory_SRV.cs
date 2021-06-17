using KabadaAPI;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class ResourceCategory {
    internal void fill(Tertex tvo) {
      var incomingO=tvo.me;
      id=incomingO.Id;
      title=incomingO.Value;
      description = incomingO.LongValue; //EGO: get description for category
      if(tvo.children.Count<1)
        return; // do not create containers for "Other"
      types=new List<ResourceType>();

      var tp=(short)EnumTexterKind.keyResourceType;

      // process types
      var c1=tvo.children.Where(x=>x.me.Kind==tp).ToList();
      foreach(var o in c1){
        var t=new ResourceType();
        types.Add(t);
        t.fill(o);
        }

      //// process selections
      //c1=tvo.children.Where(x=>x.me.Kind!=tp).ToList();
      //selections=new List<ResourceSelection>();
      //foreach(var o in c1){
      //  var t=new ResourceSelection();
      //  selections.Add(t);
      //  t.fill(o);
      //  }
      }
    }
  }
