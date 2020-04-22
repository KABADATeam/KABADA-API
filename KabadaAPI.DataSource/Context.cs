using Microsoft.EntityFrameworkCore;
using KabadaAPI.DataSource.Models;
using KabadaAPI.DataSource.Utilities;

namespace KabadaAPI.DataSource
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SQLServer);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
