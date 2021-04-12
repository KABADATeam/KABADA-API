using System;
using System.Collections.Generic;
using KabadaAPI.DataSource.Models;
using System.Linq;
using KabadaAPI.DataSource.Utilities;
using Microsoft.EntityFrameworkCore;

namespace KabadaAPI.DataSource.Repositories
{
    public class UsersRepository
    {
        protected readonly Context context;

        public UsersRepository()
        {
            context = new Context();
        }

        public User AddUser(string email, string password)
        {
            if (!Email.isValid(email))
                throw new Exception("Mismatch of email address pattern");

            if (context.Users.Where(u => u.Email == email).FirstOrDefault() != null)
                throw new Exception("This email address already registered");

            string salt = Cryptography.GetSalt();
            string passwordHash = Cryptography.GetHash(password, salt);
            string confirmationCode = Cryptography.GetHash(email, salt);

            UserType type = context.UserTypes.FirstOrDefault(x => x.Id == 100);

            User user = new User()
            {
                Surname = "",
                Name = "",
                Email = email,
                EmailConfirmed = false,
                PasswordHash = passwordHash,
                Salt = salt,
                Type = type,
                TwoFactorAuthEnabled = false
            };

            context.Users.Add(user);
            context.SaveChanges();

            Email.SendOnRegistrationConfirmation(email);

            return user;
        }

        public User AuthenticateUser(string email, string password)
        {
            var user = context.Users.Include(s => s.Type).Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
            {
                if (user.PasswordHash.Length > 0 && user.Salt.Length > 0)
                {
                    string passwordHash = Cryptography.GetHash(password, user.Salt);
                    if (user.PasswordHash.Equals(passwordHash))
                        return user;
                    else
                        throw new Exception("Wrong email or password");
                }
                else
                    throw new Exception("User cannot be authenticated");
            }
            else
                throw new Exception("Wrong email or password");
        }

        public User AuthenticateGoogleUser(string email)
        {
            var user = context.Users.Include(s => s.Type).Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
            {
                if (user.PasswordHash.Length > 0)
                    throw new Exception("Account under this email already exist");
                else
                    return user;
            }
            else
            {
                UserType type = context.UserTypes.FirstOrDefault(x => x.Id == 100);
                user = new User()
                {
                    Surname = "",
                    Name = "",
                    Email = email,
                    EmailConfirmed = false,
                    PasswordHash = "",
                    Salt = "",
                    Type = type,
                    TwoFactorAuthEnabled = false
                };

                context.Users.Add(user);
                context.SaveChanges();

                return user;
            }
        }

        public void RequestPassword(string email)
        {
            var user = context.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
            if (user != null)
            {
                if (user.PasswordHash.Length > 0)
                {
                    string confirmationCode = Cryptography.GetHash(user.Email, DateTime.Now.Ticks.ToString());
                    user.PasswordResetString = confirmationCode;

                    context.SaveChanges();

                    Email.SendPasswordResetLink(user.Email, confirmationCode);
                }
                else
                    throw new Exception("Cannot reset password for this account");
            }
        }

        public void ResetPassword(string resetString, string newPassword)
        {
            var user = context.Users.Where(u => u.PasswordResetString.Equals(resetString)).FirstOrDefault();
            if (user == null)
                throw new Exception("The link has expired");

            user.PasswordHash = Cryptography.GetHash(newPassword, user.Salt);
            user.PasswordResetString = null;

            context.SaveChanges();

            Email.SendOnPasswordChange(user.Email);
        }

        public void ChangePassword(Guid Id, string oldPassword, string newPassword)
        {
            var user = context.Users.Where(u => u.Id == Id).FirstOrDefault();
            if (user == null)
                throw new Exception("Wrong email or password");

            string passwordHash = Cryptography.GetHash(oldPassword, user.Salt);
            if (!user.PasswordHash.Equals(passwordHash))
                throw new Exception("Wrong email or password");

            user.PasswordHash = Cryptography.GetHash(newPassword, user.Salt);

            context.SaveChanges();
        }
    }
}
