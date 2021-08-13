using KabadaAPI;
using System.Collections.Generic;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class ActivitiesTypes {
    internal void read(BLontext context) {
      var tRepo=new TexterRepository(context);
      var visi=tRepo.getByKind((short)EnumTexterKind.activityType);
      visi.AddRange(tRepo.getByKind((short)EnumTexterKind.activitySubtype));
      var root=Tertex.CreateMasterTree(visi);
      if(root.children.Count<1)
        return;
      types=new List<ActivtyTypeDescriptor>();
      foreach(var t in root.children){
        var o=new ActivtyTypeDescriptor(){ id=t.me.Id, title=t.me.Value };
        types.Add(o);
        o.subtypes=new List<Codifier>();
        foreach(var s in t.children){
          o.subtypes.Add(new Codifier(){ id=s.me.Id, title=s.me.Value });
          }
        }
      }
    }
  }
