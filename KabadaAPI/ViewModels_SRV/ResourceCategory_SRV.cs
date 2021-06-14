using KabadaAPI.BL;
using KabadaAPI.DataSource.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KabadaAPI.DataSource.Repositories.TexterRepository;

namespace KabadaAPI.ViewModels {
  partial class ResourceCategory {
    internal void fill(Tertex tvo) {
      var incomingO=tvo.me;
      id=incomingO.Id;
      title=incomingO.Value;

      if(tvo.children.Count<1)
        return; // do not create containers for "Other"
      types=new List<ResourceType>();
      selections=new List<ResourceSelection>();

      var tp=(short)EnumTexterKind.keyResourceType;

      // process types
      var c1=tvo.children.Where(x=>x.me.Kind==tp).ToList();
      foreach(var o in c1){
        var t=new ResourceType();
        types.Add(t);
        t.fill(o);
        }

      // process selections
      c1=tvo.children.Where(x=>x.me.Kind!=tp).ToList();
      foreach(var o in c1){
        var t=new ResourceSelection();
        selections.Add(t);
        t.fill(o);
        }
      }
    }
  }
