using KabadaAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Kabada {
  partial class ResourceCategories {
    internal void read(BLontext context) {
      categories=new List<ResourceCategory>();

      var tRepo=new TexterRepository(context);
      var txi=tRepo.getKeyResourceMeta(); // all required texters
      var vxi=Tertex.CreateMasterTree(txi);

      foreach(var o in vxi.children){
        var t=new ResourceCategory();
        categories.Add(t);
        t.fill(o);
        }
      }
    }
  }
