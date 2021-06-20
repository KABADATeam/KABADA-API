﻿using System;
using KabadaAPIdao;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KabadaAPI {
  public class UsersRepository : BaseRepository
    {
      public UsersRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

      public User AddUser(string email, string password)
        {
            if (!Email.isValid(email))
                throw new Exception("Mismatch of email address pattern");

            if (daContext.Users.Where(u => u.Email == email).FirstOrDefault() != null)
                throw new Exception("This email address already registered");

            string salt = Cryptography.GetSalt();
            string passwordHash = Cryptography.GetHash(password, salt);
            string confirmationCode = Cryptography.GetHash(email, salt);

            UserType type = daContext.UserTypes.FirstOrDefault(x => x.Id == 100);

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

            daContext.Users.Add(user);
            daContext.SaveChanges();

            Email.SendOnRegistrationConfirmation(email, new Kmail(_config));

            return user;
        }

        public User AuthenticateUser(string email, string password)
        {
            var user = daContext.Users.Include(s => s.Type).Where(u => u.Email == email).FirstOrDefault();
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
            var user = daContext.Users.Include(s => s.Type).Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
            {
                if (user.PasswordHash.Length > 0)
                    throw new Exception("Account under this email already exist");
                else
                    return user;
            }
            else
            {
                UserType type = daContext.UserTypes.FirstOrDefault(x => x.Id == 100);
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

                daContext.Users.Add(user);
                daContext.SaveChanges();

                return user;
            }
        }

        public void RequestPassword(string email)
        {
            var user = daContext.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
            if (user != null)
            {
                if (user.PasswordHash.Length > 0)
                {
                    string confirmationCode = Cryptography.GetHash(user.Email, DateTime.Now.Ticks.ToString());
                    user.PasswordResetString = confirmationCode;

                    daContext.SaveChanges();

                    Email.SendPasswordResetLink(user.Email, confirmationCode, new Kmail(_config));
                }
                else
                    throw new Exception("Cannot reset password for this account");
            }
        }

        public void ResetPassword(string resetString, string newPassword)
        {
            var user = daContext.Users.Where(u => u.PasswordResetString.Equals(resetString)).FirstOrDefault();
            if (user == null)
                throw new Exception("The link has expired");

            user.PasswordHash = Cryptography.GetHash(newPassword, user.Salt);
            user.PasswordResetString = null;

            daContext.SaveChanges();

            Email.SendOnPasswordChange(user.Email, new Kmail(_config));
        }

        private void validatePassword(User user, string oldPassword){
          string passwordHash = Cryptography.GetHash(oldPassword, user.Salt);
          if (!user.PasswordHash.Equals(passwordHash))
            throw new Exception("Wrong email or password");
          }

        public void ChangePassword(Guid Id, string oldPassword, string newPassword)
        {
            var user = daContext.Users.Where(u => u.Id == Id).FirstOrDefault();
            if (user == null)
                throw new Exception("Wrong email or password");

            //string passwordHash = Cryptography.GetHash(oldPassword, user.Salt);
            //if (!user.PasswordHash.Equals(passwordHash))
            //    throw new Exception("Wrong email or password");
            validatePassword(user, oldPassword);

            user.PasswordHash = Cryptography.GetHash(newPassword, user.Salt);

            daContext.SaveChanges();
        }

    protected void updateBasicFields(User real, User newContents){
          real.Name=newContents.Name;
          real.Surname=newContents.Surname;
          real.EmailConfirmed=newContents.EmailConfirmed;
          real.Google=newContents.Google;
          real.Facebook=newContents.Facebook;
          real.ReceiveEmail=newContents.ReceiveEmail;
          real.ReceiveNotification=newContents.ReceiveNotification;
          }

        public void UpdateUser(Guid Id, User newContents, int updateKind=0){
            var user = daContext.Users.Where(u => u.Id == Id).FirstOrDefault();
            if (user == null)
                throw new Exception("User not found");

            switch(updateKind){
              case 1: // update without photo
                updateBasicFields(user, newContents);
                break;
              case 2: // update with photo
                updateBasicFields(user, newContents);
                user.UserPhoto=newContents.UserPhoto;
                break;
             default: throw new Exception("Internal error: invalid update kind "+updateKind.ToString());
              }

            daContext.SaveChanges();
         }

        public User Read(Guid Id)
        {
            var user = daContext.Users.Where(u => u.Id == Id).FirstOrDefault();
            if (user == null)
                throw new Exception("Wrong email or password");
            return user;
        }

    public void ChangeEmail(Guid userId, string password, string newValue) {
      var user=Read(userId);
      validatePassword(user, password);
      user.Email=newValue;
      daContext.SaveChanges();
      new Kmail(_config).SendOnMailchangeConfirmation(user.Email, user.Name);
      //Email.SendEmailChange(user.Email);
      }
    }
}