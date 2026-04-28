using App.Contatos.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Contatos.DependencyInjection.Config;

public static class ContatoContextConfig
{
    public static IServiceCollection AddDbContextConfigurantion(this IServiceCollection services, IConfiguration configuration)
    {
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}