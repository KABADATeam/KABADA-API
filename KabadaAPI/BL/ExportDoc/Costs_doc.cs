using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class Costs_doc {
        public List<CostElement_doc> fixedCosts;
        public List<CostElement_doc> variableCosts;
    }
    public class CostElement_doc
    {
        public string category;
        public string subCategory;
        public string name;
        public string desc;
    }

}
