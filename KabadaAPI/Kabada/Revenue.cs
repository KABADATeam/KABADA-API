using System;
using System.Collections.Generic;

namespace Kabada {
  public class Revenue: RevenueBase
    {   
    public string stream_type_name;
    public Guid price_category_id;
    public string price_category_name;    
    public string price_type_name;     
    public List<string> segments;
    }
  }
