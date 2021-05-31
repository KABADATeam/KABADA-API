using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI.ViewModels
{
    public class PublicBusinessPlan
    {

        public Guid Id { get; set; }
        public String name { get; set; }
        public String industry { get; set; }
        public String country { get; set; }
        public DateTime dateCreated { get; set; }
        public String owner { get; set; }
       // public byte[] ownerAvatar { get; set; }
       
    }
}
