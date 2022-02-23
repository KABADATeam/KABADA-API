using System;
using System.Collections.Generic;

namespace Kabada {
  public class KeyPartnerAI {
    public List<KeyPartnersElementAI> distributors;
    public List<KeyPartnersElementAI> suppliers;
    public List<KeyPartnersElementAI> others;
    }
  public class KeyPartnersElementAI  {
        public Guid partnerType;
        public string company; 
        public string priority; 
        public string web; 
        public string comment; 
    }
  
}
