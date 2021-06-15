using System;
using System.Collections.Generic;

namespace Kabada {
    public class PublicBusinessPlans
    {        
        public List<PublicBusinessPlan> BusinessPlan { get; set; }
        public PublicBusinessPlans()
        {
            BusinessPlan = new List<PublicBusinessPlan>();
        }

    }
}
