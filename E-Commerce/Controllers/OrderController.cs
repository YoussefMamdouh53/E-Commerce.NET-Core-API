using AutoMapper;
using E_Commerce.Models;
using E_Commerce_API.DTOs.OrderDto;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IUnitOfWork unitOfWork, UserManager<User> userManager, ILogger<OrderController> logger, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IMapper mapper = mapper;
        private readonly UserManager<User> userManager = userManager;
        private readonly ILogger<OrderController> logger = logger;

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PlaceOrder() {
            var user = await userManager.GetUserAsync(User);

            if (user == null) {
                return BadRequest();
            }

            var cartItems = unitOfWork.Carts.GetAll(c => c.UserId == user.Id);
            
            if (cartItems.Count() == 0) {
                return BadRequest("Cart is empty");
            }

            Order order = new Order()
            {
                UserId = user.Id,
                Status = "Requested",
                Items = []
            };

            
            foreach (Cart c in cartItems) {

                Product? product = unitOfWork.Products.GetById(c.ProductId);

                if (product == null)
                {
                    return BadRequest("Product not found");
                }

                if (product.Quantity < c.Quantity)
                {
                    return BadRequest("Insufficent Quantity");
                }

                OrderItem orderItem = new()
                {
                    Product = product,
                    ProductPriceInPiasters = product.UnitPriceInPiastres,
                    ProductQuantity = c.Quantity
                };

                order.Items.Add(orderItem);

                product.Quantity -= c.Quantity;
            }


            unitOfWork.Commit();
            
            return Ok(new { OrderNumber = order.OrderN});

        }
    }
}
