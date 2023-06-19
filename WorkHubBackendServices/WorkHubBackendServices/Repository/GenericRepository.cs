using Microsoft.EntityFrameworkCore;
using WorkHubBackEndServices.Data;
using WorkHubBackEndServices.Interfaces;
using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _db.Set<T>().FindAsync(id);
        }

        

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecifications<T> spec)
        {
            return SpecificationEvaluater<T>.GetQuery(_db.Set<T>().AsQueryable(), spec);

        }
    }
}
