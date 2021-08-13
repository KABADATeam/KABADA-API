using KabadaAPI;
using KabadaAPIdao;
using System;
using static KabadaAPI.Plan_AttributeRepository;

namespace Kabada {
  partial class KeyActivityPost {
    private UniversalAttributeRepository repo; 
    private string packVal { get { return null; }}

    internal Guid perform(BLontext context, Guid uGuid) {
      repo=new UniversalAttributeRepository(context);
      if(id==null)
        return createMe(context, uGuid);
      var o=repo.byId(id.Value);

      o.CategoryId=sub_type_id;
      o.MasterId=product_id;
      o.AttrVal=packVal;
      repo.daContext.SaveChanges();

      return o.Id;
      }

    private Guid createMe(BLontext context, Guid uGuid) {
      var o=new UniversalAttribute(){ Id=Guid.NewGuid(), CategoryId=sub_type_id, MasterId=product_id, Kind=(short)PlanAttributeKind.activity, AttrVal=packVal };
      repo.create(o);
      return o.Id;
      }
    }
  }
