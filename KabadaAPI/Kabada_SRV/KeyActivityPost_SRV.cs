using KabadaAPI;
using System;

namespace Kabada {
  partial class KeyActivityPost {
    private UniversalAttributeRepository repo; 
    private string packVal { get { return null; }}

    internal Guid perform(BLontext context, Guid uGuid) {
      repo=new UniversalAttributeRepository(context);
      if(id==null)
        return createMe(context, uGuid);
      var o=new KeyActivityBL(repo.byId(id.Value), true);

      o.categoryId=sub_type_id;
      o.masterId=product_id;
      o.unload();
      repo.daContext.SaveChanges();

      return o.id;
      }

    private Guid createMe(BLontext context, Guid uGuid) {
      var o=new KeyActivityBL(){ categoryId=sub_type_id, masterId=product_id };
      repo.create(o.unload());
      return o.id;
      }
    }
  }
