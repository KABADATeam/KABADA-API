using System;

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
