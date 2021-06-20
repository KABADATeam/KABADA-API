using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPIdao
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public bool EmailConfirmed { get; set; } = false;

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Salt { get; set; }

        [Required]
        public UserType Type { get; set; }

        [Required]
        public bool TwoFactorAuthEnabled { get; set; } = false;

        [Required]
        public bool Facebook { get; set; } = false;

        [Required]
        public bool Google { get; set; } = false;

        [Required]
        public bool ReceiveEmail { get; set; } = false;

        [Required]
        public bool ReceiveNotification { get; set; } = false;

        public byte[] UserPhoto { get; set; }

        public string TwoFactorString { get; set; }

        public DateTime TwoFactorStringExpiration { get; set; }

        public string EmailConfirmationString { get; set; }

        public string PasswordResetString { get; set; }

        //public virtual List<BusinessPlan> BusinessPlans { get; set; }
    }
}
