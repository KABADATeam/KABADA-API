using KabadaAPI;
using System;
using System.Collections.Generic;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class PlanPartnerTypes {

    internal void read(BLontext context) {
      distributors_types=new List<PartnerDistributorType>();
      suppliers_types=new List<PartnerSupplierType>();
      others_types=new List<PartnerOthersType>();

      var tRepo=new TexterRepository(context);
      var txi=tRepo.getKeyPartnerMeta(); // all required texters
      if(txi.Count<1)
        return;

      PartnerTypeBase o=null;
      foreach(var x in txi){
        switch(x.Kind){
          case (short)EnumTexterKind.keyDistributors: { var t=new PartnerDistributorType(); distributors_types.Add(t); o=t; } break;
          case (short)EnumTexterKind.keySuppliers: { var t=new PartnerSupplierType(); suppliers_types.Add(t); o=t; } break;
          case (short)EnumTexterKind.keyPartnersOther: { var t=new PartnerOthersType(); others_types.Add(t); o=t; } break;
          default: throw new Exception("this should never occur...");
          }
        o.description=x.LongValue;
        o.title=x.Value;
        o.type_id=x.Id;
        }
      }
    }
  }
