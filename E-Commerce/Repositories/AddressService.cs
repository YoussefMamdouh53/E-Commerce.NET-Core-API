using E_Commerce.Data;
using E_Commerce.Interfaces;
using E_Commerce.Models;
using E_Commerce_API.Repositories;

namespace E_Commerce.Repositories
{
    public class AddressService(DataContext ctx) : Repository<Address>(ctx), IAddressService
    {
        
        
    }
}