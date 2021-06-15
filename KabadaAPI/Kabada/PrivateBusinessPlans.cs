using System;
using System.Collections.Generic;

namespace Kabada {
    public class PrivateBusinessPlans
    {        
        public List<PrivateBusinessPlan> BusinessPlan { get; set; }
        public PrivateBusinessPlans()
        {
            BusinessPlan = new List<PrivateBusinessPlan>();
        }
    }
}
