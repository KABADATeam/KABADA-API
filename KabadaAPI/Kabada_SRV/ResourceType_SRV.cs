using KabadaAPI;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class ResourceType {

    //internal void fill(Texter incomingO, List<Texter> children) {
    //  id=incomingO.Id;
    //  title=incomingO.Value;
    //  //var todo=children.;
    //  }

    internal void fill(Tertex tvo) {
      id=tvo.me.Id;
      title=tvo.me.Value;

      //subTypes=new List<ResourceSubType>();
      //foreach(var o in tvo.children){
      //  var t=new ResourceSubType();
      //  subTypes.Add(t);
      //  t.fill(o);
      //  }

      // process selections
      var tp=(short)EnumTexterKind.keyResourceType;
      var c1=tvo.children.Where(x=>x.me.Kind!=tp).ToList();
      selections=new List<ResourceSelection>();
      foreach(var o in c1){
        var t=new ResourceSelection();
        selections.Add(t);
        t.fill(o);
        }
      }
    }
  }
