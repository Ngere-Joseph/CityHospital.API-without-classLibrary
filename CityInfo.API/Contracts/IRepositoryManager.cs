namespace CityInfo.API.Contracts
{
    public interface IRepositoryManager
    {
        ICityRepository City { get; }
        IHospitalRepository Hospital { get; }
        IDoctorRepository Doctor { get; }
        void Save();
    }
}
