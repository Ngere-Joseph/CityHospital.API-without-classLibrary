using CityInfo.API.Contracts;

namespace CityInfo.API.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private ICityRepository _cityRepository;
        private IHospitalRepository _hospitalRepository;
        private AppDbContext _appDbContext;

        public RepositoryManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ICityRepository City
        {
            get
            {
                if (_cityRepository == null)
                    _cityRepository = new CityRepository(_appDbContext);

                return _cityRepository;
            }
        }

        public IHospitalRepository Hospital
        {
            get
            {
                if (_hospitalRepository == null)
                    _hospitalRepository = new HospitalRepository(_appDbContext);

                return _hospitalRepository;
            }
        }

        public void Save() => _appDbContext.SaveChanges();

    }
}
