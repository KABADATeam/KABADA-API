using System;
using System.Collections.Generic;

namespace KabadaAPI.ViewModels
{
    public class PrivateBusinessPlans
    {        
        public List<PrivateBusinessPlan> BusinessPlan { get; set; }
        public PrivateBusinessPlans()
        {
            BusinessPlan = new List<PrivateBusinessPlan>();
        }
    }
}
