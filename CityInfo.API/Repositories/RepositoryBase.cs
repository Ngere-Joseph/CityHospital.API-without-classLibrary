using CityInfo.API.Contracts;
using CityInfo.API.Data.DTOs;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CityInfo.API.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        protected AppDbContext AppDbContext;

        public RepositoryBase(AppDbContext _context)
        {
            AppDbContext = _context;
        }

        public void Create(T entity) => AppDbContext.Set<T>().Add(entity);

        public void Delete(T entity) => AppDbContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            AppDbContext.Set<T>()
            .AsNoTracking() : AppDbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? AppDbContext.Set<T>().Where(expression).AsNoTracking() : AppDbContext.Set<T>().Where(expression);

        public T GetById(int id) => AppDbContext.Set<T>().Find(id);
        

        public void Update(T entity) => AppDbContext.Set<T>().Update(entity);

        public IEnumerable<Hospital> GetAllHospitalPerCity(int cityId) => AppDbContext.hospitals.Where(h => h.CityId == cityId).ToList();

        public Hospital? GetSingleHospitalPerCity(int cityId, int id) => AppDbContext.hospitals.Where(h => h.CityId == cityId && h.Id == id).FirstOrDefault();

        public bool CityExist(int cityId) => AppDbContext.cities.Any(c => c.Id == cityId);
        
    }
}
