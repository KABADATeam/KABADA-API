﻿using static KabadaAPI.TexterRepository;

namespace KabadaAPI {
  partial class BusinessSegmentPOST {
    protected override void fill(CustomerSegmentUniversal t) {
      fill(t, EnumTexterKind.industry, business_type);
      fill(t, EnumTexterKind.company_size, company_size);
      t.v1=annual_revenue;
      t.v2=budget;
      fill(t, EnumTexterKind.income, income);
      fill(t, EnumTexterKind.geographic_location, geographic_location);
      }
    }
  }