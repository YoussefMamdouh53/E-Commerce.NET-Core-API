using AutoMapper;
using E_Commerce.DTO.AddressDTO;
using E_Commerce.Models;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace E_Commerce_API.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController(IUnitOfWork unitOfWork,
        IMapper mapper,
        UserManager<User> userManager,
        ILogger<AddressController> logger) : ControllerBase {

        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<User> _userManager = userManager;
        private readonly ILogger<AddressController> _logger = logger;

        [Authorize]
        [HttpGet]
        public  IActionResult GetAllAddressesdByUser() {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return BadRequest();

            var addresses = _unitOfWork.Addresses.GetAll(a => a.UserId == userId);
            return Ok(addresses);
        }
        [HttpPost]
        public IActionResult CreateAddress(AddressDTO addressDTO) {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return BadRequest();

            var address = _mapper.Map<Address>(addressDTO);
            address.UserId = userId;

            _unitOfWork.Addresses.Create(address);
            _unitOfWork.Commit();

            return Ok(address);
        }

        [HttpPut]
        public IActionResult UpdateAddress(AddressDTO addressDTO) {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return BadRequest();

            var address = _mapper.Map<Address>(addressDTO);
            address.UserId = userId;

            _unitOfWork.Addresses.Update(address);
            _unitOfWork.Commit();

            return Ok();
        } 

        [HttpDelete]
        public IActionResult RemoveAddressById(int id) {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return BadRequest();

            var address = _unitOfWork.Addresses.GetById(id);
            
            if (address == null)
                return NotFound();

            if (address.UserId != userId)
                return Forbid();

            _unitOfWork.Addresses.Delete(address);
            _unitOfWork.Commit();
            return Ok();
        }
    }

}
