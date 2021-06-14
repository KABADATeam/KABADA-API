using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KabadaAPIdao
{
  public class UserFile
  {
    [Key]
    public Guid Id { get; set; }
    public Guid? UserId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public byte[] Content { get; set; }
  }
}
