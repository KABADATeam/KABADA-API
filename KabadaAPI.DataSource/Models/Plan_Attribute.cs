﻿using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao {
  public class Plan_Attribute {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid BusinessPlanId { get; set; }
        public BusinessPlan BusinessPlan { get; set; }

        [Required]
        public Guid TexterId { get; set; }
        public Texter Texter { get; set; }

        [Required]
        [Range(1,20)]
        public short Kind { get; set; }

        [Required]
        public string AttrVal { get; set; } // json-ed attribute value - has different types depending on Kind
    }
  }
