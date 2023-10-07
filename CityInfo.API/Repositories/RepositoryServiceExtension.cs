using CityInfo.API.Contracts;

namespace CityInfo.API.Repositories
{
    public static class RepositoryServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services) 
            => services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
