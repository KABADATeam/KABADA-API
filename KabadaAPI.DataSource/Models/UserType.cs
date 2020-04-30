using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPI.DataSource.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
