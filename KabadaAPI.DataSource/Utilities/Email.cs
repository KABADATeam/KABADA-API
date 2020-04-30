using System;
using System.ComponentModel.DataAnnotations;

namespace KabadaAPI.DataSource.Utilities
{
    public static class Email
    {
        public static bool isValid(string emailAddress)
        {
            return (new EmailAddressAttribute()).IsValid(emailAddress);
        }
    }
}
