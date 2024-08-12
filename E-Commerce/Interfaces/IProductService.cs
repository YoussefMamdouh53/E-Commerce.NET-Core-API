using E_Commerce.Models;
using System.Linq.Expressions;

namespace E_Commerce_API.Interfaces
{
    public interface IProductService : IRepository<Product>
    {
        IEnumerable<Product> GetProductsByPage(int page, int take);

        int GetTotalProductCount(Expression<Func<Product, bool>>? expression = null);
    }
}
