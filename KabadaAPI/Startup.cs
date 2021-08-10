using KabadaAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace KabadaAPI {
  public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            // services.AddDbContext<DataSource.Context>(options => // [vp]
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("KabadaAPI.DataSource")));

            services.ConfigureCors();
            services.ConfigureJWTAuthentication(Configuration);
            services.ConfigureJWTAuthorization();
            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddSwaggerGen(c => // [vp]
            {
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "kabada-api", Version = "v1" });
            });
        //   services.AddSingleton<IWorker, BackgroundJobber>();
        //   services.AddHostedService<BackgroundJobsService>(); 
           }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();  
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");

            //new JobRepository(new BLontext(Configuration, loggerFactory.CreateLogger("batch"))).runAll(); 

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger(); // [vp]
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "kabada-api v1"));
            }


            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();

            if (env.IsProduction()) // [vp]
            {
                app.UseDefaultFiles();
                app.UseStaticFiles();
                // app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
