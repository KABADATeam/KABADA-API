using Microsoft.EntityFrameworkCore;
using KabadaAPI.DataSource.Models;
using KabadaAPI.DataSource.Utilities;
using System;

namespace KabadaAPI.DataSource
{
    public class Context : DbContext
    {   //public Context(DbContextOptions<Context> options) : base(options){}//aaaaaaaaaaaaaaaaaaaaaaaaaa
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<UserBusinessPlan> UserBusinessPlans { get; set; }//aaaaaaaaaa
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SQLServer);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.Entity<UserBusinessPlan>().OwnsOne(x => x.BusinessPlans);
            modelBuilder.Entity<UserBusinessPlan>().Property(x => x.Id)//aaaaaa
                   .ValueGeneratedOnAdd();//aaaaaaa
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

            modelBuilder.Entity<Country>().Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Country>().HasData(new Country { Id= Guid.NewGuid() ,Title = "Belgium", ShortCode = "BE" });
          
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid() ,Title = "Bulgaria", ShortCode = "BG" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid() , Title = "Czechia", ShortCode = "CZ" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Denmark", ShortCode = "DK" });
           
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Germany", ShortCode = "DE" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Estonia", ShortCode = "EE" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Ireland", ShortCode = "IE" });
           
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Greece", ShortCode = "EL" });
           
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Spain", ShortCode = "ES" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "France", ShortCode = "FR" });
         
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Croatia", ShortCode = "HR" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Italy", ShortCode = "IT" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Cyprus", ShortCode = "CY" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Latvia", ShortCode = "LV" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Lithuania", ShortCode = "LT" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Luxembourg", ShortCode = "LU" });
           
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Hungary", ShortCode = "HU" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Malta", ShortCode = "MT" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Netherlands", ShortCode = "NL" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Austria", ShortCode = "AT" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Poland", ShortCode = "PL" });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Portugal", ShortCode = "PT" });
            base.OnModelCreating(modelBuilder);
        }
      
    }
}
