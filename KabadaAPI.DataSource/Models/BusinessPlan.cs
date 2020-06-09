using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KabadaAPI.DataSource.Models
{
    public class BusinessPlan
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Country Country { get; set; }

        [Required]
        public Activity Activity { get; set; }

        [Required]
        public string Title { get; set; }   
    }
}
