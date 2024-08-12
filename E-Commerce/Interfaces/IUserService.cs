using E_Commerce.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IUserService : IRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
