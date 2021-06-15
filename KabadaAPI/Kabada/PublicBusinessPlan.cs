using System;

namespace Kabada {
  public class PublicBusinessPlan
    {

        public Guid Id { get; set; }
        public String name { get; set; }
        public String industry { get; set; }
        public String country { get; set; }
        public DateTime dateCreated { get; set; }
        public String owner { get; set; }
        public byte[] ownerAvatar { get; set; }
       
    }
}
