using KabadaAPI;
using System.Linq;

namespace Kabada {
  partial class CustomerRelationshipActions {
    internal void read(BLontext context) {
       var tRepo=new TexterRepository(context);
      var txi=tRepo.getCustomerRelationshipActions(); // all required texters
      categories=txi.Select(x=>new Codifier { id=x.Id, title=x.Value }).ToList();
      }
    }
  }
