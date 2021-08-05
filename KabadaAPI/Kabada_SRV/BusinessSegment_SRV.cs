using System;
using System.Collections.Generic;
using static KabadaAPI.TexterRepository;

namespace KabadaAPI {
  partial class BusinessSegment {
    internal override void unpack(CustomerSegmentUniversal w, Dictionary<Guid, Codifier> codes) {
      business_type=w.decode(EnumTexterKind.industry, codes);
      company_size=w.decode(EnumTexterKind.company_size, codes);
      annual_revenue=w.v1;
      budget=w.v2;
      income=w.decode(EnumTexterKind.income, codes);
      geographic_location=w.decode(EnumTexterKind.geographic_location, codes);
      }
    }
  }
