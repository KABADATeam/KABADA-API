using KabadaAPI.DataSource.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.DataSource.Repositories.TexterRepository;

namespace KabadaAPI.ViewModels {
  partial class ResourceCategories {
    internal void read(IConfiguration config, ILogger logger) {
      categories=new List<ResourceCategory>();

      var tRepo=new TexterRepository(config, logger);
      var txi=tRepo.getKeyResourceMeta(); // all required texters
      
      var k=(short)EnumTexterKind.keyResourceCategory;
      var cli=txi.Where(x=>x.Kind==k).ToList();              // top leyer

      foreach(var o in cli){
        var t=new ResourceCategory();
        t.fill(o, txi);
        categories.Add(t);
        }
      }
    }
  }
