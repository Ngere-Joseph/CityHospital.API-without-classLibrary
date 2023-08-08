namespace CityInfo.API.Contracts
{
    public interface IRepositoryManager
    {
        ICityRepository City { get; }
        IHospitalRepository Hospital { get; }
        void Save();
    }
}
