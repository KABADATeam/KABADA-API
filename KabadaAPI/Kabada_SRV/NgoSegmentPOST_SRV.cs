﻿using KabadaAPI;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  public partial class NgoSegmentPOST {
    protected override void fill(CustomerSegmentElementBL t) {
      fill(t, EnumTexterKind.public_bodies_ngo, ngo_types);
      }
    }
  }
