using CityInfo.API.Contracts;
using CityInfo.API.Entities;

namespace CityInfo.API.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
