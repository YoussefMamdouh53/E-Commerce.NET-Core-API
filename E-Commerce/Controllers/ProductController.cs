using AutoMapper;
using E_Commerce.Models;
using E_Commerce_API.DTOs.ProductDTO;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Params.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public IActionResult GetProductByPage([FromQuery] ProductPagingReqParams reqParams)
        {
            return Ok(new {
                items = _unitOfWork.Products.GetProductsByPage(reqParams.Page, reqParams.ProductsPerPage),
                max_page = (_unitOfWork.Products.GetTotalProductCount())
            });
        }

        [HttpGet("{name}")]
        public IActionResult SearchForProduct(string name)
        {
            return Ok(_unitOfWork.Products.Find(p => p.Name.Contains(name) || p.Description.Contains(name)));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public IActionResult AddProduct(ProductDTO productDTO) {
            _unitOfWork.Products.Create(_mapper.Map<Product>(productDTO));
            _unitOfWork.Commit();
            return Ok();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        public IActionResult UpdateProduct(ProductDTO productDTO)
        {
            _unitOfWork.Products.Update(_mapper.Map<Product>(productDTO));
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
