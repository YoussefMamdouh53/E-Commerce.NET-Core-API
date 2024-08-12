using AutoMapper;
using E_Commerce.DTO.UserDTO;
using E_Commerce.Models;
using E_Commerce_API.DTOs.ReviewDTO;
using E_Commerce_API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<User> _userManager = userManager;
        [HttpGet]
        public IActionResult GetReviewsByProductId(int product_id) {
            return Ok(_unitOfWork.Reviews.GetAll(r => r.ProductId == product_id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateReview(CreateReviewRequest reviewDTO) { 
            var product = _unitOfWork.Products.GetById(reviewDTO.ProductId);
            var userId = _userManager.GetUserId(User);

            if (product == null)
                return NotFound();

            if (userId == null) {
                return BadRequest();
            }

            _unitOfWork.Reviews.Create(new Review { 
                Title = reviewDTO.Title,
                Body = reviewDTO.Body,
                Stars = reviewDTO.Stars,
                ProductId = product.Id,
                UserId = userId
            });

            _unitOfWork.Commit();

            return Ok();

        }

    }
}
