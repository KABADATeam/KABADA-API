using KabadaAPI.BL;
using System.Collections.Generic;

namespace KabadaAPI.ViewModels {
  partial class ResourceType {

    //internal void fill(Texter incomingO, List<Texter> children) {
    //  id=incomingO.Id;
    //  title=incomingO.Value;
    //  //var todo=children.;
    //  }

    internal void fill(Tertex tvo) {
      id=tvo.me.Id;
      title=tvo.me.Value;

      subTypes=new List<ResourceSubType>();
      foreach(var o in tvo.children){
        var t=new ResourceSubType();
        subTypes.Add(t);
        t.fill(o);
        }
      }
    }
  }
