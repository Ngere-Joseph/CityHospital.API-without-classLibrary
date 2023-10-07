using CityInfo.API.Contracts;
using CityInfo.API.Data;
using CityInfo.API.Entities;

namespace CityInfo.API.Repositories
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext appDbContext): base(appDbContext)
        {
        }
    }
}
