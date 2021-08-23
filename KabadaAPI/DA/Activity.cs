using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao {
  public class Activity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Guid IndustryId { get; set; }
        public virtual Industry Industry { get; set; }

        public Guid? ContainerActivityId { get; set; }
    }
}
