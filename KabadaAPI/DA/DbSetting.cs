using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao {
  public class DbSetting {
    [Key]
    public string Id { get; set; }

    [Required]
    public string Value { get; set; }
    }
}
