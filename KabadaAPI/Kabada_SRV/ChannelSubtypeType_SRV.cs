using KabadaAPI;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class ChannelSubtypeType {
    internal override void fill(Tertex tvo) {
            base.fill(tvo);
           // id= tvo.me.Id;
      //name= tvo.me.Value;     
      if(tvo.children.Count<1)
        return; 
      // process location types
      location_types=new List<ChannelBase>();
      var tp=(short)EnumTexterKind.channelLocationType;      
      var c1=tvo.children.Where(x=>x.me.Kind==tp).ToList();
      foreach(var o in c1){
        var t=new ChannelBase();
        location_types.Add(t);
        t.fill(o);
      }
        // process distribution channels
        distribution_channels=new List<ChannelBase>();
        tp=(short)EnumTexterKind.channelDistribution;      
        c1=tvo.children.Where(x=>x.me.Kind==tp).ToList();
        foreach(var o in c1){
          var t=new ChannelBase();
          distribution_channels.Add(t);
          t.fill(o);
        }
      }
    }
  }
