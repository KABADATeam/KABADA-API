using System;
using System.Collections.Generic;
using static KabadaAPI.TexterRepository;

namespace KabadaAPI {
  partial class NgoSegment {
    internal override void unpack(CustomerSegmentUniversal w, Dictionary<Guid, Codifier> codes) {
      ngo_types=w.decode(EnumTexterKind.public_bodies_ngo, codes);
      }
    }
  }
