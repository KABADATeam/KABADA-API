using Microsoft.EntityFrameworkCore;
using KabadaAPI.DataSource.Models;
using KabadaAPI.DataSource.Utilities;

namespace KabadaAPI.DataSource
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
<<<<<<< HEAD
        public DbSet<Country> Countries { get; set; }

=======
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
>>>>>>> cc57adec159412e014c670f5c3043f39128b08c4

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SQLServer);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<RefreshToken>().Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 1, Title = "Administrator" });
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 100, Title = "Simple" });

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
