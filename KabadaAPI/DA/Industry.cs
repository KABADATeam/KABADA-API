﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao {
  public class Industry
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Title { get; set; }

        public string Language { get; set; }

    //    public virtual List<Activity> Activities { get; set; }
        public Industry clone(){ return (Industry)this.MemberwiseClone(); }
 
    }
}
