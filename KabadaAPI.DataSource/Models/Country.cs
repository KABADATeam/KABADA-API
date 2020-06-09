using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPI.DataSource.Models
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ShortCode { get; set; }
    }
}
