using EnergyEndpoint.Application.Interfaces;
using EnergyEndpoint.Application.Mappings;
using EnergyEndpoint.Application.Services;
using EnergyEndpoint.Infra.Data;
using EnergyEndpoint.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EnergyEndpoint.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<EnergyEndpointDbContext>()
                    .AddSingleton<EndpointRepository>()
                    .AddTransient<IEndpointService, EndpointService>()
                    .AddAutoMapper(typeof(DomainToViewModelMappingProfile),
                                   typeof(ViewModelToDomainMappingProfile))
                    .AddMemoryCache();


            return services;
        }
    }
}
