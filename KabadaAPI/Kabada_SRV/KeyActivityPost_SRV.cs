using KabadaAPI;
using System;

namespace Kabada {
  partial class KeyActivityPost {
    //private UniversalAttributeRepository repo; 
    //private string packVal { get { return null; }}

    //private void assign(KeyActivityBL bo){
    //  bo.categoryId=sub_type_id;
    //  bo.masterId=product_id;
    //  bo.e.name=name;
    //  bo.e.description=description;
    //  }

    //internal Guid perform(BLontext context, Guid uGuid) {
    //  repo=new UniversalAttributeRepository(context);
    //  if(id==null)
    //    return createMe(context, uGuid);
    //  var o=new KeyActivityBL(repo.byId(id.Value), true);
    //  assign(o);
    //  o.unload();
    //  repo.daContext.SaveChanges();
    //  return o.id;
    //  }

    //private Guid createMe(BLontext context, Guid uGuid) {
    //  var o=new KeyActivityBL();
    //  assign(o);
    //  repo.create(o.unload());
    //  return o.id;
    //  }

    internal Guid perform(BLontext context, Guid uGuid) {
      var repo=new UniversalAttributeRepository(context);
      var o=KeyActivityBL.Make(id, repo);
      assign(o);
      var w=o.unload();
      if(id==null)
        repo.create(w);
       else
        repo.daContext.SaveChanges();
      return o.id;
      }

    private void assign(KeyActivityBL bo){
      bo.categoryId=sub_type_id;
      bo.masterId=product_id;
      bo.e.name=name;
      bo.e.description=description;
      }
    }
  }
