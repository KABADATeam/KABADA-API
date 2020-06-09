using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace KabadaAPI.DataSource.Models
{
 public class UserBusinessPlan
    {
        [Key]
        public Guid Id { get; set; }
        public User User {get;set;}
        public List<BusinessPlan> BusinessPlans { get; set; }
    }
}
