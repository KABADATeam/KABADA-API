using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public partial class ConsumerSegmentPOST : CustomerSegmentPostBase {
    public bool is_children;
    public List<Guid> age;
    public List<Guid> gender;
    public List<Guid> education;
    public List<Guid> income;
    public List<Guid> geographic_location;
    }
  }
