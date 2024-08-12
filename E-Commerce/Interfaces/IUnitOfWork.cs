using E_Commerce.Interfaces;

namespace E_Commerce_API.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressService Addresses { get; }
        IProductService Products { get; }
        ICategoryService Categories { get; }
        IReviewService Reviews { get; }
        ICartService Carts { get; }
        IOrderService Orders { get; }
        IOrderItemService OrderItems { get; }
        int Commit();
    }
}
