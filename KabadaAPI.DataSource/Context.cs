using Microsoft.EntityFrameworkCore;
using KabadaAPI.DataSource.Models;
using KabadaAPI.DataSource.Utilities;

namespace KabadaAPI.DataSource
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SQLServer);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().Property(x => x.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {

         }
         */
    }
}
