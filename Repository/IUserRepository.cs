using Ecommerce.Models;

namespace Ecommerce.Repository
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        User GetUser(int id);
    }
}