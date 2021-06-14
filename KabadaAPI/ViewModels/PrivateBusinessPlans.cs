using System;
using System.Collections.Generic;

namespace KabadaAPI {
    public class PrivateBusinessPlans
    {        
        public List<PrivateBusinessPlan> BusinessPlan { get; set; }
        public PrivateBusinessPlans()
        {
            BusinessPlan = new List<PrivateBusinessPlan>();
        }
    }
}
