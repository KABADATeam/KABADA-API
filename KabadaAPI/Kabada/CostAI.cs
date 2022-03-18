using System;
using System.Collections.Generic;

namespace Kabada {
  public class CostAI {
        public List<CostElementAI> fixedCosts;
        public List<CostElementAI> variableCosts;
    }
    public class CostElementAI
    {
        public Guid id;
        public Guid category;
        public Guid subCategory;
        public string name;
        public string desc;
    }

}
