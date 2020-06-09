using System;
using System.Collections.Generic;
using System.Text;

namespace KabadaAPI.DataSource.Models
{
  public  class BusinessPlan
    {
        
        public Guid Id { get; set; }
        public Country Country { get; set; }
        public Activity Activity { get; set; }
        public string Title { get; set; }
    
    }
}
