using CityInfo.API.Data.DTOs;
using CityInfo.API.Entities;
using System.Linq.Expressions;

namespace CityInfo.API.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        T GetById(int id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        public IEnumerable<Hospital> GetAllHospitalPerCity(int cityId);
        public Hospital? GetSingleHospitalPerCity(int cityId, int id);
        public bool CityExist(int cityId);
    }
}
