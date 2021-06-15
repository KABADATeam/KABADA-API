using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
