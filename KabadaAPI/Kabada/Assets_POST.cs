using System;
using System.Collections.Generic;

namespace Kabada {
  public partial class Assets_POST {
    public Guid business_plan_id;
        public decimal? total_investments;
        public decimal? own_assets;
        public decimal? investment_amount;          
        public List<AssetPosterElement> physical_assets;
    }
  }
