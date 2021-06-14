using Microsoft.EntityFrameworkCore;
using KabadaAPIdao;
using KabadaAPI.DataSource.Utilities;
using Microsoft.Extensions.Configuration;

namespace KabadaAPI.DataSource {
  public partial class Context : DbContext
    {
        public Context(IConfiguration configuration) : base() { Configuration = configuration; }

        protected static AppSettings _opt;
        protected AppSettings opt { get {
          if(_opt==null)
            _opt=new AppSettings(Configuration);
          return _opt;
          }}
     
 
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
        public DbSet<Texter>     Texters     { get; set; } 
        //public DbSet<Plan_SWOT>  Plan_SWOTs  { get; set; } 
        public DbSet<Plan_Attribute>  Plan_Attributes  { get; set; } 
        // public Context(DbContextOptions<Context> options) : base(options) { } // [vp]


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConnectionStrings.SQLServer);
            if (!optionsBuilder.IsConfigured)
            {
               var cstr=opt.connectionString;
               var prov=opt.connectionProvider.ToUpper();
               switch(prov){ 
                 case "POSTGRES": optionsBuilder.UseNpgsql(cstr); break;
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
            AddData_UserTypes(modelBuilder);
            AddData_Countries(modelBuilder);
            AddData_SWOTtexters(modelBuilder);
            AddData_KeyResourcesTexters(modelBuilder);
        }
    }
}
