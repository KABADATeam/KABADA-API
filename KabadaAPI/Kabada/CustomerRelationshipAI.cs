using System;
using System.Collections.Generic;

namespace Kabada {
  public class CustomerRelationshipAI
    {
    public List<CustRelElementAI> getCust;    
    public List<CustRelElementAI> keepCust;
    public List<CustRelElementAI> convCust;
    }
    public class CustRelElementAI
    {
        public Guid action;
        public List<string> channel; 
    }
}
