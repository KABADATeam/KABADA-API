using System;
using System.Collections.Generic;

namespace KabadaAPI {
    public class PublicBusinessPlans
    {        
        public List<PublicBusinessPlan> BusinessPlan { get; set; }
        public PublicBusinessPlans()
        {
            BusinessPlan = new List<PublicBusinessPlan>();
        }

    }
}
