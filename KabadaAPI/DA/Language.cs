using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao {
  public class Language {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Title { get; set; }
    }
  }
