using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Repositories
{
    public class CategoryService(DataContext ctx) : Repository<Category>(ctx), ICategoryService
    {
        public IEnumerable<Category> GetAllPrimaryCategories()
        {
            return _dbSet.Where(c => c.SubCategoryId == null).ToList();
        }

        public IEnumerable<Category> GetSubCategories(Category category)
        {
            return _dbSet.Where(c => c.SubCategoryId == category.Id).ToList();
        }

    }
}
