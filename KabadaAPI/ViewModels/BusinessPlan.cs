using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI.ViewModels
{
    public class BusinessPlan
    {       
            public Guid Id { get; set; }
            public Country Country { get; set; }
            public Activity Activity { get; set; }
            public string Title { get; set; }

       
    }
}
