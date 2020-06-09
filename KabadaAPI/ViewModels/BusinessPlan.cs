using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI.ViewModels
{
    public class BusinessPlan
    {       
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public Guid ActivityId { get; set; }
        public string Title { get; set; }
    }
}
