using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao
{
    public class Job  {
       [Key]
       public Guid Id { get; set; }

       [Required]
       public short Kind { get; set; }

       public string Value { get; set; }
       public string Lookup { get; set; }
       public Guid? Author { get; set; }

       [Required]
       public DateTime CreatedAt { get; set; }
       public DateTime? ExpiresAt { get; set; }
    }
}
