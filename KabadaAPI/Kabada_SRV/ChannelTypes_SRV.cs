using KabadaAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Kabada {
  partial class ChannelTypes {
    internal void read(BLontext context) {
      channel_types=new List<ChannelType>();

      var tRepo=new TexterRepository(context);
      var txi=tRepo.getChannelTypesMeta(); // all required texters
      var vxi=Tertex.CreateMasterTree(txi);

      foreach(var o in vxi.children){
        var t=new ChannelType();
        channel_types.Add(t);
        t.fill(o);
        }
      }
    }
  }
