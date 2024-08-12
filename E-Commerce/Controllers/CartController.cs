using AutoMapper;
using E_Commerce.Models;
using E_Commerce_API.DTOs.CartDTO;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(IUnitOfWork unitOfWork, UserManager<User> userManager, ILogger<CartController> logger, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly UserManager<User> userManager = userManager;
        private readonly ILogger<CartController> logger = logger;
        private readonly IMapper mapper = mapper;

        [Authorize]
        [HttpGet]
        public IActionResult GetCartItems()
        {
            var userId = userManager.GetUserId(User);
            var cartItems = unitOfWork.Carts.GetAll(c => c.UserId == userId).Select(c => mapper.Map<CartItemDTO>(c));
            return Ok(cartItems);
        }

        [Authorize]
        [HttpPost("Add")]
        public IActionResult AddCartItem(CartItemDTO cartItem) {
            var userId = userManager.GetUserId(User);
            var product = unitOfWork.Products.Find(p => p.Id == cartItem.ProductId);

            if (userId == null) {
                return BadRequest();
            }
            
            if (product == null)
                return NotFound("Product not found");

            var cart = unitOfWork.Carts.Find(c => c.ProductId == cartItem.ProductId && c.UserId == userId);

            if (cart != null)
            {
                cartItem.Quantity += cart.Quantity;
                return UpdateQuantity(cartItem);
            }
            else
            {
                cart = mapper.Map<Cart>(cartItem);
                cart.UserId = userId;
                unitOfWork.Carts.Create(cart);
            }      

            unitOfWork.Commit();
            return Ok();
        }

        [Authorize]
        [HttpPost("Update")]
        public IActionResult UpdateQuantity(CartItemDTO cartItem) {
            var userId = userManager.GetUserId(User);
            var product = unitOfWork.Products.Find(p =>p.Id == cartItem.ProductId);

            if (product == null)
                return NotFound("Product not found");

            var cart = unitOfWork.Carts.Find(c => c.Id == cartItem.Id && c.UserId == userId);

            if (cart == null)
                return NotFound("Cart item not found");

            if (cartItem.Quantity > product.Quantity)
                return BadRequest("Insufficient Product");

            cart.Quantity = cartItem.Quantity;

            unitOfWork.Commit();

            return Ok();
        
        }

        [Authorize]
        [HttpDelete("Delete{cartId}")]
        public IActionResult Delete(int cartId) { 
            var cart = unitOfWork.Carts.Find(p => p.Id == cartId);

            if (cart == null) { 
                return BadRequest();
            }

            unitOfWork.Carts.Delete(cart);
            unitOfWork.Commit();

            return Ok();
        }


    }
}
