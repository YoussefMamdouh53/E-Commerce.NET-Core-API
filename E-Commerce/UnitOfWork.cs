using E_Commerce.Data;
using E_Commerce.Interfaces;
using E_Commerce.Repositories;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Repositories;

namespace E_Commerce_API
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext ctx;
        public UnitOfWork(DataContext ctx)
        {
            this.ctx = ctx;
            Addresses = new AddressService(ctx);
            Products = new ProductService(ctx);
            Categories = new CategoryService(ctx);
            Reviews = new ReviewService(ctx);
            Carts = new CartService(ctx);
            Orders = new OrderService(ctx);
            OrderItems = new OrderItemService(ctx);
        }


        public IAddressService Addresses { get; private set; }
        public IReviewService Reviews { get; private set; }

        public IProductService Products { get; private set; }
        public ICategoryService Categories { get; private set; }
        public ICartService Carts { get; private set; }
        public IOrderService Orders { get; private set; }
        public IOrderItemService OrderItems { get; private set; }

        public int Commit()
        {
            return ctx.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
        }

    }
}
