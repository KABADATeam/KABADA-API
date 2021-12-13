using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class RevenueStream_doc
    {
        public List<RevenueStreamElement_doc> consumer;
        public List<RevenueStreamElement_doc> business;
        public List<RevenueStreamElement_doc> publicNgo; 
    }
    public class RevenueStreamElement_doc
    {
        public string name;
        public string prices;
        public string pricingType;
        public string consumers; //comma separated list of customer segments' names    
    }   
}
