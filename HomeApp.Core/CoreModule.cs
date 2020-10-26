using HomeApp.Core.Database;
using HomeApp.Core.Repositories.Recipes;
using HomeApp.Core.Repositories.Users;
using HomeApp.Core.Services;
using HomeApp.Core.Services.Interfaces;
using HomeApp.Core.Services.Recipes;
using HomeApp.Core.Services.Users;
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
            services.AddTransient<GetRecipesService>();
            services.AddTransient<AddUpdateRecipeService>();
            services.AddScoped<RecipesRepository>();

            services.AddScoped<UsersRepository>();
            services.AddTransient<UserAdministrationService>();

            return services;
        }
    }
}
