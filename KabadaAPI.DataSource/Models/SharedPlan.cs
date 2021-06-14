using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao
{
    public class SharedPlan
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid BusinessPlanId { get; set; }
        public BusinessPlan BusinessPlan { get; set; }
    }
}
