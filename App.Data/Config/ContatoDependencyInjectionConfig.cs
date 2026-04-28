using App.Application.Service;
using App.Application.Service.Interface;
using App.Domain.Interface;
using App.Domain.Interfaces;
using App.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.Config;

public static class ContatoDependencyInjectionConfig
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IContatoRepository, ContatoRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();

        // Services
        services.AddScoped<IContatoService, ContatoService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IPedidoService, PedidoService>();
        services.AddScoped<IEnderecoService, EnderecoService>();

        return services;    
    }
}