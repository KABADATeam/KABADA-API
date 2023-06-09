﻿using Microsoft.EntityFrameworkCore;
using KabadaAPIdao;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KabadaAPI {
  public partial class DAcontext : DbContext
    {
       public BLontext context { get; private set; }

       public DAcontext(IConfiguration configuration, ILogger logger=null ) : base() { Configuration = configuration; context=new BLontext(configuration, logger);}

        protected static AppSettings _opt;
        protected AppSettings opt { get {
          if(_opt==null)
            _opt=new AppSettings(Configuration);
          return _opt;
          }}
     
 
        public DAcontext() { }

        public IConfiguration Configuration { get; private set; }
        public DbSet<KabadaAPIdao.Activity> Activities { get; set; }
        public DbSet<KabadaAPIdao.Country> Countries { get; set; }
        public DbSet<KabadaAPIdao.Industry> Industries { get; set; }
        public DbSet<KabadaAPIdao.RefreshToken> RefreshTokens { get; set; }
        public DbSet<KabadaAPIdao.User> Users { get; set; }
        public DbSet<KabadaAPIdao.UserType> UserTypes { get; set; }
        public DbSet<KabadaAPIdao.BusinessPlan> BusinessPlans { get; set; }

        public DbSet<KabadaAPIdao.UserFile> UserFiles { get; set; } // [vp]

        public DbSet<KabadaAPIdao.SharedPlan> SharedPlans { get; set; } 
        public DbSet<KabadaAPIdao.Texter>     Texters     { get; set; } 
        public DbSet<KabadaAPIdao.Plan_Attribute>  Plan_Attributes  { get; set; } 
        public DbSet<KabadaAPIdao.Language>  Languages  { get; set; } 
        // public Context(DbContextOptions<Context> options) : base(options) { } // [vp]
        public DbSet<KabadaAPIdao.Plan_SpecificAttribute>  Plan_SpecificAttributes  { get; set; } 
        public DbSet<KabadaAPIdao.DbSetting>     DbSettings     { get; set; } 
        public DbSet<KabadaAPIdao.Job>    Jobs     { get; set; } 
        public DbSet<KabadaAPIdao.UniversalAttribute>    UniversalAttributes     { get; set; } 
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConnectionStrings.SQLServer);
            if (!optionsBuilder.IsConfigured)
            {
               var cstr=opt.connectionString;
               var prov=opt.connectionProvider.ToUpper();
               switch(prov){ 
           //      case "POSTGRES": optionsBuilder.UseNpgsql(cstr); break;
                default:  
                 case "MS": optionsBuilder.UseSqlServer(cstr); break;
                 }
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
            
            AddData(modelBuilder);
           
            base.OnModelCreating(modelBuilder);
        }

        private void AddData(ModelBuilder modelBuilder)
        {
// System.Diagnostics.Debugger.Launch();
 //var useOldFunctions=false;
 //         if(useOldFunctions){
 //           AddData_UserTypes(modelBuilder);
 //           AddData_Countries(modelBuilder);
 //           AddData_SWOTtexters(modelBuilder);
 //           AddData_KeyResourcesTexters(modelBuilder);
 //           AddData_PartnersTypes(modelBuilder);
 //           AddData_Languages(modelBuilder);
 //           AddData_NACE(modelBuilder);
 //           AddData_ProductsTypes(modelBuilder);
 //           AddData_ProductFeatures(modelBuilder);
 //           AddData_ProductIncomeSources(modelBuilder);
 //           AddData_ProductsPriceLevels(modelBuilder);
 //           AddData_ProductsInnovativeOptions(modelBuilder);
 //           AddData_ProductsQualityOptions(modelBuilder);
 //           AddData_ProductsDiffOptions(modelBuilder);
 //           AddData_CostTypes(modelBuilder);
 //           AddData_RevenueStreamTypes(modelBuilder);
 //           AddData_RevenuePriceTypes(modelBuilder);
 //           AddData_ChannelTypes(modelBuilder);
 //           AddData_CustomerSegmentCodifiers(modelBuilder);
 //           AddData_CustomerActions(modelBuilder);
 //          } else
            AddData_DBinit(modelBuilder);
            }
    }
}
