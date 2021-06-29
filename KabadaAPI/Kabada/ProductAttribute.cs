using System;
using System.Collections.Generic;

namespace Kabada {
  public partial class ProductAttribute {
        
        public string title;
        public Guid product_type;
        public string description;
        public Guid price_level;
        public List<Guid> selected_additional_income_sources;
        public List<Guid> product_features;
        public Guid innovative_level;
        public Guid quality_level;
        public Guid differentiation_level;
    }
  }
