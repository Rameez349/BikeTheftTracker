using Application.Interfaces;
using Infrastructure.Core.Options;
using Infrastructure.Core.Services;

namespace BikeTheftTracker.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureBikeIndexApiOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BikeIndexApiOptions>(configuration.GetSection(BikeIndexApiOptions.Key));
        }

        public static void ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IBikeIndexApiClient, BikeIndexApiClient>();
        }
    }
}
