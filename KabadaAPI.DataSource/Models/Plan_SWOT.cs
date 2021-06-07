using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPI.DataSource.Models {
  public class Plan_SWOT {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public BusinessPlan BusinessPlan { get; set; }

        [Required]
        public Texter Texter { get; set; }

        [Required]
        [Range(1,2)]
        public short Kind { get; set; }
    }
  }
