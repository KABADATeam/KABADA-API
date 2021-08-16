using KabadaAPI;
using System;
using System.Collections.Generic;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class ConsumerSegment {
    internal override void unpack(CustomerSegmentElementBL w, Dictionary<Guid, Codifier> codes) {
      is_children=(w.flag==true);
      age=w.decode(EnumTexterKind.age_group, codes);
      gender=w.decode(EnumTexterKind.gender, codes);
      education=w.decode(EnumTexterKind.education, codes);
      income=w.decode(EnumTexterKind.income, codes);
      geographic_location=w.decode(EnumTexterKind.geographic_location, codes);
      }
    }
  }
