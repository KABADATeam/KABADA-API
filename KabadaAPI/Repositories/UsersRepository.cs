using System;
using KabadaAPIdao;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KabadaAPI {
  public partial class UsersRepository : BaseRepository {
      public UsersRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

      private DbSet<User> q0 { get { return daContext.Users; }}

      public IQueryable<User> qID(Guid id) { return q0.Where(x=>x.Id==id); }

      public IQueryable<User> qMail(string eMail) { return q0.Where(x=>x.Email==eMail); }
 
      public IQueryable<User> Q() { return q0.AsQueryable(); }

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
                TypeId = type.Id,
                TwoFactorAuthEnabled = false
            };

            daContext.Users.Add(user);
            daContext.SaveChanges();

            BackgroundJobber.Notify();

            //Email.SendOnRegistrationConfirmation(email, new Kmail(_config));
            new Kmail(_config).sendOnRegistrationConfirmation(email);
            return user;
        }

        public UserJoin AuthenticateUser(string email, string password){
          var uJ=join(qMail(email)).FirstOrDefault();
          var user=uJ?.us;
          //  var user = daContext.Users.Include(s => s.Type).Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
            {
                if (user.PasswordHash.Length > 0 && user.Salt.Length > 0)
                {
                    string passwordHash = Cryptography.GetHash(password, user.Salt);
                    if (user.PasswordHash.Equals(passwordHash))
                        return uJ;
                    else
                        throw new Exception("Wrong email or password");
                }
                else
                    throw new Exception("User cannot be authenticated");
            }
            else
                throw new Exception("Wrong email or password");
        }

        public UserJoin AuthenticateGoogleUser(string email) {
            var uJ=join(qMail(email)).FirstOrDefault();
            var user=uJ?.us;
            //var user = daContext.Users.Include(s => s.Type).Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
            {
                if (user.PasswordHash.Length > 0)
                    throw new Exception("Account under this email already exist");
                else
                    return uJ;
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
                    TypeId = type.Id,
                    TwoFactorAuthEnabled = false
                };

                daContext.Users.Add(user);
                daContext.SaveChanges();

                return new UserJoin(){ us=user, ut=type };
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

                    //Email.SendPasswordResetLink(user.Email, confirmationCode, new Kmail(_config));
                    new Kmail(_config).sendPasswordResetLink(user.Email, confirmationCode);
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

            //Email.SendOnPasswordChange(user.Email, new Kmail(_config));
            new Kmail(_config).sendOnPasswordChange(user.Email);
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

      BackgroundJobber.Notify();

      new Kmail(_config).sendOnMailchangeConfirmation(user.Email, user.Name);
      //Email.SendEmailChange(user.Email);
      }

    protected override object[] getAll4snap() { return daContext.Users.ToArray(); }
    protected override string myTable => "Users";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.User, Guid>(daContext.Users, json, overwrite, oldDeleted, generateInits);
      }

    internal List<User> Read(List<Guid> mGuis) {
      var r=q0.Where(x=>mGuis.Contains(x.Id)).ToList();
      return r;
      }

    internal User byEmail(string email) {
      var r=q0.Where(x=>x.Email==email).FirstOrDefault();
      return r;
      }

    protected override void adjust(object me) {
      var o=(KabadaAPIdao.User)me;
      if(o.TypeId==0)
        o.TypeId=100;
      }

    protected override Guid? guid(string json) {
      var o = Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.User>(json);
      return o.Id;
      }

    public IQueryable<UserJoin> join(IQueryable<User> uQ){
      var r=from u in uQ
            join t in daContext.UserTypes  on u.TypeId  equals t.Id
            select new UserJoin { us=u, ut=t };
      return r;
      }
    public UserJoin join(Guid user){ return join(qID(user)).FirstOrDefault(); }
    }
}
