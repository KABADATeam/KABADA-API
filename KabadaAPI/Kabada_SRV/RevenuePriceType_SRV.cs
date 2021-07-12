using KabadaAPI;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class RevenuePriceType {
    internal void fill(Tertex tvo) {
      id=tvo.me.Id;
      title=tvo.me.Value;

            types = new List<RevenueAttribute>();
            foreach (var o in tvo.children)
            {
                var t = new RevenueAttribute();
                types.Add(t);
                t.id = o.me.Id;
                t.title = o.me.Value;
            }

      }
    }
  }
