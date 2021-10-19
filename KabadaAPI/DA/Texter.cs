using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao {
  public class Texter {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Value { get; set; }

        [Required]
        [Range(1,100)]
        public short Kind { get; set; }

        public Guid? MasterId { get; set; } // at the moment BusinessPlan.Id when defined locally in the plan

        //[MaxLength(500)]
        public string LongValue { get; set; }
        [Required] 
        public short OrderValue { get; set; }
    }
  }
