﻿using System;
using System.Collections.Generic;

namespace Kabada {
  public class KeyPartnerAI {
    public List<KeyPartnersElementAI> distributors;
    public List<KeyPartnersElementAI> suppliers;
    public List<KeyPartnersElementAI> others;
    }
  public class KeyPartnersElementAI  {
        public Guid id;
        public Guid partnerType;
        public string company; 
        public bool priority; //yes,no
        public string web; 
        public string comment; 
    }
  
}
