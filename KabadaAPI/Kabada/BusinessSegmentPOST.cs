using System;
using System.Collections.Generic;

namespace Kabada {
  public partial class BusinessSegmentPOST : CustomerSegmentPostBase {
    public List<Guid> business_type;
    public List<Guid> company_size;
    public string annual_revenue;
    public string budget;
    public List<Guid> income;
    public List<Guid> geographic_location;
    }
  }
