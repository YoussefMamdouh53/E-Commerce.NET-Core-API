using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce_API.Repositories
{
    public class ProductService(DataContext ctx) : Repository<Product>(ctx), IProductService
    {
        public IEnumerable<Product> GetProductsByPage(int page, int take) {
            return _dbSet.Skip((page - 1) * 20).Take(take).OrderBy(p => p.Id).ToList();
        }

        public int GetTotalProductCount(Expression<Func<Product, bool>>? expression = null)
        {
            IQueryable<Product> queryable = _dbSet;
            if (expression != null) { 
                queryable.Where(expression);
            }
            return queryable.Count();
        }

    }
}
