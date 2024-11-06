using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repository;

namespace API.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IClienteRepository, ClienteRespository>();
            services.AddScoped<IEnderecoRespository, EnderecoRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            return services;
        }
    }
}
