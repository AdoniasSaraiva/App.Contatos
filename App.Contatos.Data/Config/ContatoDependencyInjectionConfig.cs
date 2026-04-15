using App.Contatos.Application.Service;
using App.Contatos.Application.Service.Interface;
using App.Contatos.Data.Repository;
using App.Contatos.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace App.Contatos.Infra.Config;

public static class ContatoDependencyInjectionConfig
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IContatoRepository, ContatoRepository>();
        
        services.AddScoped<IContatoService, ContatoService>();

        return services;    
    }
}