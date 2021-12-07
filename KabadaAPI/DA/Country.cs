using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ShortCode { get; set; }
        public Country clone(){ return (Country)this.MemberwiseClone(); }
    }
}
