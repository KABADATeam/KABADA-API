using KabadaAPI;
using System;
using System.Collections.Generic;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class RevenueStreamTypes {

    internal void read(BLontext context) {
      stream_types=new List<RevenueAttribute>();     

      var tRepo=new TexterRepository(context);
      var txi=tRepo.getRevenueStreamTypes(); // all required texters
      if(txi.Count<1)
        return;
      foreach(var x in txi){
        var t = new RevenueAttribute();
        if (x.Kind == (short)EnumTexterKind.revenueStreamType) stream_types.Add(t);
        t.id=x.Id;
        t.title=x.Value;        
        }
      }
    }
  }
