using System;
using System.Collections.Generic;
using KabadaAPI.DataSource.Models;
using System.Linq;

namespace KabadaAPI.DataSource.Repositories
{
    public class UsersRepository
    {
        protected readonly Context context;

        protected UsersRepository()
        {
            context = new Context();
        }

        public List<User> GetUser()
        {
            return context.Users.ToList();
        }
    }
}
