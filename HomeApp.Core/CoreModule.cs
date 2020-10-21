using HomeApp.Core.Database;
using HomeApp.Core.Services;
using HomeApp.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HomeApp.Core
{
    public static class CoreModule
    {
        public static IServiceCollection AddCoreConfig(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CoreDatabaseContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("MyConnection"));
            }
            );
            services.AddSingleton<IUserService,UserService>();

            return services;
        }
    }
}
