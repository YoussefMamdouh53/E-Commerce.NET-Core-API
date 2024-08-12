using E_Commerce.Data;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;

namespace E_Commerce_API.Repositories
{
    public class CartService(DataContext ctx) : Repository<Cart>(ctx), ICartService
    {
    }
}
