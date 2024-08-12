
using E_Commerce.Data;
using E_Commerce_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace E_Commerce_API.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _ctx;
        protected readonly DbSet<T> _dbSet;

        public Repository(DataContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? expression = null, IEnumerable<string>? includes = null)
        {
            IQueryable<T> queryable = _dbSet.AsQueryable();

            if (expression != null)
            {
                queryable = queryable.Where(expression);
            }

            if (includes != null)
            {
                foreach (var propery in includes)
                {
                    queryable = queryable.Include(propery);
                }
            }

            return queryable.AsNoTracking().ToList();
        }

        public T? Find(Expression<Func<T, bool>>? expression = null, IEnumerable<string>? includes = null) {
            IQueryable<T> queryable = _dbSet.AsQueryable();

            if (expression != null)
            {
                queryable = queryable.Where(expression);
            }

            if (includes != null)
            {
                foreach (var propery in includes)
                {
                    queryable = queryable.Include(propery);
                }
            }

            return queryable.AsNoTracking().FirstOrDefault();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Update(entity);
        }

        public int Save() { 
            return _ctx.SaveChanges();
        }
    }
}
