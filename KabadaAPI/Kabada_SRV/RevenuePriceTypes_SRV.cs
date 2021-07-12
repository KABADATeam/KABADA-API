using KabadaAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Kabada {
  partial class RevenuePriceTypes {
    internal void read(BLontext context) {
      prices=new List<RevenuePriceType>();

      var tRepo=new TexterRepository(context);
      var txi=tRepo.getRevenuePriceMeta(); // all required texters
      var vxi=Tertex.CreateMasterTree(txi);

      foreach(var o in vxi.children){
        var t=new RevenuePriceType();
        prices.Add(t);
        t.fill(o);
        }
      }
    }
  }
