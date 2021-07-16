using KabadaAPI;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class ChannelSubtype {
    internal override void fill(Tertex tvo) {
      base.fill(tvo);     
      if(tvo.children.Count<1)
        return; 
      types=new List<ChannelSubtypeType>();

      var tp=(short)EnumTexterKind.channelSubtypeType;

      // process subtype types
      var c1=tvo.children.Where(x=>x.me.Kind==tp).ToList();
      foreach(var o in c1){
        var t=new ChannelSubtypeType();
        types.Add(t);
        t.fill(o);
        }
      }
    }
  }
