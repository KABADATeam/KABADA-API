﻿using Microsoft.EntityFrameworkCore;
using KabadaAPI.DataSource.Models;
using KabadaAPI.DataSource.Utilities;
using System;
using Microsoft.Extensions.Configuration;

namespace KabadaAPI.DataSource
{
    public class Context : DbContext
    {
        public Context(IConfiguration configuration) : base() { Configuration = configuration; }
 
        public Context() { }

        public IConfiguration Configuration { get; private set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<BusinessPlan> BusinessPlans { get; set; }

        public DbSet<UserFile> UserFiles { get; set; } // [vp]

        public DbSet<SharedPlan> SharedPlans { get; set; } 
        // public Context(DbContextOptions<Context> options) : base(options) { } // [vp]


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConnectionStrings.SQLServer);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(new AppSettings(Configuration).connectionString);
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=kabada-test;Trusted_Connection=True;MultipleActiveResultSets=true");
                //optionsBuilder.UseSqlServer(@"name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<BusinessPlan>().Property(x => x.Id)
                   .ValueGeneratedOnAdd();
            modelBuilder.Entity<Country>().Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Industry>().Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<RefreshToken>().Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserFile>().Property(x => x.Id) // [vp]
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<BusinessPlan>().Property(x => x.Created)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<SharedPlan>().Property(x => x.Id) 
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 1, Title = "Administrator" });
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 100, Title = "Simple" });

            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Austria", ShortCode = "AT" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Bosnia and Herzegovina", ShortCode = "BA" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Belgium", ShortCode = "BE" });          
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Bulgaria", ShortCode = "BG" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Croatia", ShortCode = "HR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Cyprus", ShortCode = "CY" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Czechia", ShortCode = "CZ" });           
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Denmark", ShortCode = "DK" });           
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Estonia", ShortCode = "EE" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Finland", ShortCode = "FI" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "France", ShortCode = "FR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Germany", ShortCode = "DE" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Greece", ShortCode = "EL" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Hungary", ShortCode = "HU" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Iceland", ShortCode = "IS" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Ireland", ShortCode = "IE" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Italy", ShortCode = "IT" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Latvia", ShortCode = "LV" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Liechtenstein", ShortCode = "LI" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Lithuania", ShortCode = "LT" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Luxembourg", ShortCode = "LU" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Malta", ShortCode = "MT" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Netherlands", ShortCode = "NL" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "North Macedonia", ShortCode = "MK" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Norway", ShortCode = "NO" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Poland", ShortCode = "PL" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Portugal", ShortCode = "PT" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Romania", ShortCode = "RO" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Serbia", ShortCode = "RS" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Slovakia", ShortCode = "SK" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Slovenia", ShortCode = "SI" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Spain", ShortCode = "ES" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Sweden", ShortCode = "SE" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Switzerland", ShortCode = "CH" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Turkey", ShortCode = "TR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "United Kingdom", ShortCode = "UK" });

            base.OnModelCreating(modelBuilder);
        }
      
    }
}
