using KabadaAPI;
using System;
using System.Collections.Generic;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class NgoSegment {
    internal override void unpack(CustomerSegmentElementBL w, Dictionary<Guid, Codifier> codes) {
      ngo_types=w.decode(EnumTexterKind.public_bodies_ngo, codes);
      }
    }
  }
