using KabadaAPI.DataSource.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  partial class ResourceCategories {
    internal void read(IConfiguration config, ILogger logger) {
      categories=new List<ResourceCategory>();

      var tRepo=new TexterRepository(config, logger);
      var txi=tRepo.getKeyResourceMeta(); // all required texters
      var vxi=Tertex.CreateMasterTree(txi);

      foreach(var o in vxi.children){
        var t=new ResourceCategory();
        categories.Add(t);
        t.fill(o);
        }
      }

    internal void read1(Guid planId, IConfiguration config, ILogger logger) {
      }
    }
  }
