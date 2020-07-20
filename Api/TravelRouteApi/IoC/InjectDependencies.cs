using Microsoft.Extensions.DependencyInjection;
using TravelRouteApi.Business;
using TravelRouteApi.Business.Impl;
using TravelRouteApi.Repository.Impl;
using TravelRouteApi.Service;
using TravelRouteApi.Service.Impl;

namespace TravelRouteApi.IoC
{
    public class InjectDependencies
    {
        internal static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IRouteRepository, InMemoryRouteRepository>();
            services.AddScoped<IBestRouteService, BestRouteService>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<ILowestPriceFinder, DijkstraLowestPriceFinder>();
            services.AddScoped<IGraphCreator, GraphCreator>();
            services.AddScoped<IFindFactory, FindFactory>();
            services.AddScoped<IDijkstraImplementation, DijkstraImplementation>();
        }
    }
}
