using System;
using System.Collections.Generic;
using KabadaAPI.DataSource.Models;
using System.Linq;

namespace KabadaAPI.DataSource.Repositories
{
    public class UsersRepository
    {
        protected readonly Context context;

        public UsersRepository()
        {
            context = new Context();
        }



        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public void AddUser(string userName, string password)
        {
            User usr = context.Users.FirstOrDefault(u => u.UserName.Equals(userName));

            if (usr == null)
            {
                User user = new User()
                {
                    Id = Guid.NewGuid(),
                    UserName = userName,
                    Password = password
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Such user already exists");
            }
        }

        public void UpdatePassword(string userName, string password)
        {
            User usr = context.Users.FirstOrDefault(u => u.UserName.Equals(userName));

            if (usr != null)
            {
                usr.Password = password;
                context.SaveChanges();
            }
        }
    }
}
