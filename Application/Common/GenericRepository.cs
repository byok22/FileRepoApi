using Microsoft.EntityFrameworkCore;
using TodoApi.Infrastructure.Persistance;

namespace TodoApi
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TE_TestProductivityContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(TE_TestProductivityContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
     
        public Task<T> Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);              
        }

        public Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<IEnumerable<T>> GetAll()
        {
           var list = _dbSet.ToList();
              return Task.FromResult(list.AsEnumerable());
        }

        public Task<T> GetById(int id)
        {
            return Task.FromResult(_dbSet.Find(id));
        }

        public Task Save()
        {
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return Task.CompletedTask;  
        }
    }
}