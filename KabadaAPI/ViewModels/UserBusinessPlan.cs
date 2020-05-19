using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI.ViewModels
{
    public class UserBusinessPlan
    {   public Guid Id { get; set; }
        public  UserViewModel User { get; set; }
        public List<BusinessPlan> BusinessPlans { get; set; }
    }
}