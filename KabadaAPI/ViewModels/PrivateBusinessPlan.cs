using System;

namespace KabadaAPI {
  public class PrivateBusinessPlan
    {

        public Guid Id { get; set; }
        public String name { get; set; }      
        public DateTime dateCreated { get; set; }
        public bool Public { get; set; }
        public Guid? planImage { get; set; }
        public int Percentage { get; set; }
        public bool SharedWithMe { get; set; }

    }
}
