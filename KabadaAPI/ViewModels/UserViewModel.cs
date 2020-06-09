using System;
namespace KabadaAPI.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool TwoFactorAuthEnabled { get; set; } = false;
        public string Role { get; set; }
    }
}
