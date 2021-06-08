using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPI.DataSource.Models {
  public class Plan_SWOT {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid BusinessPlanId { get; set; }
        public BusinessPlan BusinessPlan { get; set; }

        [Required]
        public Guid TexterId { get; set; }
        public Texter Texter { get; set; }

        [Required]
        [Range(1,2)]
        public short Kind { get; set; }
    }
  }
