using AutoMapper;
using E_Commerce.DTO.AddressDTO;
using E_Commerce.DTO.UserDTO;
using E_Commerce.Models;
using E_Commerce_API.DTO.UserDTO;
using E_Commerce_API.DTOs.CartDTO;
using E_Commerce_API.DTOs.CategoryDTO;
using E_Commerce_API.DTOs.ProductDTO;
using E_Commerce_API.Models;

namespace E_Commerce_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            //User
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();

            //Category
            CreateMap<Category, CategoryDTO>().ReverseMap();

            //Product
            CreateMap<Product, ProductDTO>().ReverseMap();

            //Address
            CreateMap<Address, AddressDTO>().ReverseMap();


            //Cart
            CreateMap<Cart, CartItemDTO>().ReverseMap();


        }
    }
}
