using CityInfo.API.Contracts;
using CityInfo.API.Data;
using CityInfo.API.Entities;

namespace CityInfo.API.Repositories
{
    public class HospitalRepository : RepositoryBase<Hospital>, IHospitalRepository
    {
        public HospitalRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
