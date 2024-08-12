using E_Commerce.Data;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;

namespace E_Commerce_API.Repositories
{
    public class OrderService(DataContext ctx) : Repository<Order>(ctx) , IOrderService
    {
    }
}
