using AutoMapper;
using E_Commerce.Models;
using E_Commerce_API.DTOs.CategoryDTO;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public IActionResult GetAllPrimaryCategories() {
            return Ok(_unitOfWork.Categories.GetAllPrimaryCategories());
        }

        [HttpGet("{id}")]
        public IActionResult GetAllSubCategories(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);

            if (category == null)
                return NotFound();


            return Ok(_unitOfWork.Categories.GetSubCategories(category));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public IActionResult CreateCategory(CategoryDTO categoryDTO) { 
            _unitOfWork.Categories.Create(_mapper.Map<Category>(categoryDTO));
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
