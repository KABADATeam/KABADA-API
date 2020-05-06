using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPI.DataSource.Models
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CountryName { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string CountryNr { get; set; }
    }
}
