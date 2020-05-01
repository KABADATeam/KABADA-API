using Microsoft.EntityFrameworkCore;
using KabadaAPI.DataSource.Models;
using KabadaAPI.DataSource.Utilities;

namespace KabadaAPI.DataSource
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Industry> Industries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SQLServer);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Industry>().Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<RefreshToken>().Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 1, Title = "Administrator" });
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 100, Title = "Simple" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
