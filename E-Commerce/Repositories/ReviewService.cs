using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce_API.Interfaces;

namespace E_Commerce_API.Repositories
{
    public class ReviewService(DataContext ctx) : Repository<Review>(ctx), IReviewService
    {
    }
}
