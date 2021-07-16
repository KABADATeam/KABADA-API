using KabadaAPI;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class ChannelType {
    internal override void fill(Tertex tvo) {
      base.fill(tvo);     
      if(tvo.children.Count<1)
        return; 
      subtypes=new List<ChannelSubtype>();

      var tp=(short)EnumTexterKind.channelSubtype;

      // process subtypes
      var c1=tvo.children.Where(x=>x.me.Kind==tp).ToList();
      foreach(var o in c1){
        var t=new ChannelSubtype();
        subtypes.Add(t);
        t.fill(o);
        }      
      }
    }
  }
