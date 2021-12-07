using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class KeyPartners_doc {
    public List<KeyPartnersElement_doc> distributors;
    public List<KeyPartnersElement_doc> suppliers;
    public List<KeyPartnersElement_doc> others;
    }
  public class KeyPartnersElement_doc  {
        public string partnerType;
        public string company; 
        public string priority; 
        public string web; 
        public string comment; 
    }
  
}
