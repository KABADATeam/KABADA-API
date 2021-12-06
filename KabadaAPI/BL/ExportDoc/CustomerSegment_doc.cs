using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class CustomerSegment_doc {
    public List<ConsumerSegment_doc> consumer;    
    public List<BusinessSegment_doc> business;
    }
  public class ConsumerSegment_doc {
        public string segment_name;
        public string age; //comma separated list of names
        public string gender; //comma separated list of names
        public string education; //comma separated list of names
        public string income; //comma separated list of names
        public string geographic_location; //comma separated list of names
    }
  public class BusinessSegment_doc {
        public string segment_name;
        public string business_type; //comma separated list of names
        public string company_size; //comma separated list of names       
        public string geographic_location; //comma separated list of names
    }
}
