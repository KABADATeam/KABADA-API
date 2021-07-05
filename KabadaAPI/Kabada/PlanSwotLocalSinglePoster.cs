using System;
using System.Collections.Generic;

namespace Kabada {
  public partial class PlanSwotLocalSinglePoster {
    public Guid business_plan_id { get; set; }
    public SwotUpdater swot { get; set; }
    public short kind { get; set; } //0 - strengths&weaknesses; > 0 -opportuninies&threads
    }
  }
