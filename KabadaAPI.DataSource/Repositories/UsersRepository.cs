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
    }
}
