using CityInfo.API.Contracts;

namespace CityInfo.API.Repositories
{
    public static class RepositoryServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        }
    }
}
