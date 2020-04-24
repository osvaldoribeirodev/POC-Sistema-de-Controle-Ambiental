using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SCA.ModuloAtivo.Api.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> FindAll(string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes != null)
                foreach (var includeProperty in includes)
                    query = query.Include(includeProperty).AsNoTracking();

            return query.ToList();
        }

        public IEnumerable<TEntity> FindAll()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity FindById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        
        public void Insert(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
