using System.Linq.Expressions;

namespace E_Commerce_API.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T? GetById(int id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? expression = null, IEnumerable<string>? includes = null);
        T? Find(Expression<Func<T, bool>>? expression = null, IEnumerable<string>? includes = null);
        int Save();
    }
}
