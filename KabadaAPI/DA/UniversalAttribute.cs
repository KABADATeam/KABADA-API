using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao {
  public class UniversalAttribute {
        [Key]
        public Guid Id { get; set; }

        public Guid? MasterId { get; set; }
 
        [Required]
        [Range(1,50)]
        public short Kind { get; set; }
 
        [Required]
        public string AttrVal { get; set; } // json-ed attribute value - has different types depending on Kind

        [Required] 
        public short OrderValue { get; set; }

        public Guid? CategoryId { get; set; }

    public UniversalAttribute clone(){ return (UniversalAttribute)this.MemberwiseClone(); }
    }
  }
