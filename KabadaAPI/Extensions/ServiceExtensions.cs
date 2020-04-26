using System;
using Microsoft.Extensions.DependencyInjection;

namespace KabadaAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder => {

                    builder.WithOrigins("http://localhost:3000").AllowAnyMethod();
                    builder.WithHeaders("Access-Control-Allow-Origin", "*");
                    builder.WithHeaders("Access-Control-Allow-Headers", "Authorization, Origin, WWW-Authenticate, Content-Length, X-Requested-With, Content-Type, Accept");
                });
            });
        }
    }
}
