using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPI.DataSource.Models {
  public class Texter {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Value { get; set; }

        [Required]
        [Range(1,100)]
        public short Kind { get; set; }
        
        public Guid Master { get; set; } // at the moment BusinessPlan.Id when defined locally in the plan

        [MaxLength(500)]
        public string LongValue { get; set; }
    }
  }
