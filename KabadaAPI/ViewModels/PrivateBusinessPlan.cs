using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI.ViewModels
{
    public class PrivateBusinessPlan
    {

        public Guid Id { get; set; }
        public String name { get; set; }      
        public DateTime dateCreated { get; set; }
        public bool Public { get; set; }
        public bool Shared { get; set; }
        public Guid? planImage { get; set; }
        public int Percentage { get; set; }
        public bool SharedWithMe { get; set; }

    }
}
