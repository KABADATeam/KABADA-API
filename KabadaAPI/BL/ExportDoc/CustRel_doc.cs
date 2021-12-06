using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class CustRel_doc
    {
    public List<CustRelElement_doc> getCust;    
    public List<CustRelElement_doc> keepCust;
    public List<CustRelElement_doc> convCust;
    }
    public class CustRelElement_doc
    {
        public string action;
        public string channel; //comma separated list of names
    }
}
