using KabadaAPI.DataSource.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KabadaAPI.DataSource.Repositories.TexterRepository;

namespace KabadaAPI.ViewModels {
  partial class ResourceCategory {
    internal void fill(Texter incomingO, List<Texter> txi) {
      id=incomingO.Id;
      title=incomingO.Value;
      description=incomingO.LongValue;
      var children=txi.Where(x=>x.MasterId==id).ToList();
      if(children.Count<1)
        return; // do not create containers for "Other"

      types=new List<ResourceType>();
      var k=(short)EnumTexterKind.keyResourceType;
      var todo=children.Where(x=>x.Kind==k).ToList();
      foreach(var o in todo){
        var t=new ResourceType();
        types.Add(t);
        t.fill(o, children);
        }

      //selections=new List<ResourceSelection>();

      //var looki=txi.ToDictionary(x=>x.Id);
      }
    }
  }
