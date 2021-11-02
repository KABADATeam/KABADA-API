using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class IndustryWood {
    internal void read(BLontext context, IndustryActivityRepository iRepo) {
      var industries = iRepo.GetIndustries();
      var dika=new Dictionary<Guid, ActivityNode>();
      foreach (var item in industries){
        var o=new ActivityNode() { Id=item.Id, Title=item.Title, Code=item.Code };
        dika.Add(o.Id, o);
        Add(o);
        }
      var acti=iRepo.q0.ToList();
      while(acti.Count>0){
        var pro=false;
        for(var i=0; i<acti.Count; i++){
          var o=acti[i];
          var cont=o.ContainerActivityId;
          if(cont==null)
            cont=o.IndustryId;
          if(cont!=null){
            if(dika.ContainsKey(cont.Value)==false)
              continue;
            register(o, dika, cont.Value);
            }
          pro=true;
          acti[i]=null;
          }
        if(pro==false)
          break; // abandon not referemced
        acti=acti.Where(x=>x!=null).ToList();
        }
      }

    private void register(KabadaAPIdao.Activity o, Dictionary<Guid, ActivityNode> dika, Guid masterId) {
      var master=dika[masterId];
      var n=new ActivityNode(){ Id=o.Id, Code=o.Code, Title=o.Title };
      dika.Add(n.Id, n);
      if(master.activities==null)
        master.activities=new List<ActivityNode>();
      master.activities.Add(n);
      }
    }
  }
