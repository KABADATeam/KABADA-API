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

        public User AddUser(string name, string email, string password)
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
                Name = name,
                Surname = "",
                Email = email,
                EmailConfirmed = false,
                PasswordHash = passwordHash,
                Salt = salt,
                Type = type,
                TwoFactorAuthEnabled = false
            };

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        public User AuthenticateUser(string email, string password)
        {
            var user = context.Users.Include(s => s.Type).Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
            {
                string passwordHash = Cryptography.GetHash(password, user.Salt);
                if (user.PasswordHash.Equals(passwordHash))
                    return user;
                else
                    throw new Exception("Wrong email or password");
            }
            else
                throw new Exception("Wrong email or password");
        }
    }
}
