using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class CustomerSegmentAI {
    public List<ConsumerSegmentAI> consumer;    
    public List<BusinessSegmentAI> business;
    public List<PublicSegmentAI> publicNgo; 
    }
  public class ConsumerSegmentAI {
        public Guid segment_id;
        public List<Guid> age; 
        public List<Guid> gender; 
        public List<Guid> education; 
        public List<Guid> income; 
        public List<Guid> geographic_location; 
    }
  public class BusinessSegmentAI {
        public Guid segment_id;
        public List<Guid> business_type; 
        public List<Guid> company_size;    
        public List<Guid> geographic_location; 
    }
    public class PublicSegmentAI
    {
        public Guid segment_id;
        public List<Guid> business_type;
    }
}
