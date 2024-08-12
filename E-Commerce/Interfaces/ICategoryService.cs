using E_Commerce.Models;

namespace E_Commerce_API.Interfaces
{
    public interface ICategoryService : IRepository<Category>
    {
        IEnumerable<Category> GetAllPrimaryCategories();
        IEnumerable<Category> GetSubCategories(Category category);
    }
}
