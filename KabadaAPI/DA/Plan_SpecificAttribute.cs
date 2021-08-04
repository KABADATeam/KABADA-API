using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao {
  public class Plan_SpecificAttribute {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid BusinessPlanId { get; set; }
        public BusinessPlan BusinessPlan { get; set; }

        [Required]
        [Range(1,50)]
        public short Kind { get; set; }
 
        [Required]
        public string AttrVal { get; set; } // json-ed attribute value - has different types depending on Kind

        [Required] 
        public short OrderValue { get; set; }

        public string Comment;
    }
  }
