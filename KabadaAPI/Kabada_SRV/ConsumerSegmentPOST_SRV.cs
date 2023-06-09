﻿using KabadaAPI;
using System;
using static KabadaAPI.Plan_AttributeRepository;
using static KabadaAPI.TexterRepository;

namespace Kabada {
  partial class ConsumerSegmentPOST {
    protected override void fill(CustomerSegmentElementBL t) {
      fill(t, EnumTexterKind.age_group, age);
      fill(t, EnumTexterKind.gender, gender);
      t.flag=is_children;
      t.segment_name=segment_name;
      fill(t, EnumTexterKind.education, education);
      fill(t, EnumTexterKind.income, income);
      fill(t, EnumTexterKind.geographic_location, geographic_location);
      }
    }
  }
