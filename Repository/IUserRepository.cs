using Ecommerce.Models;

namespace Ecommerce.Repository
{
    public interface IUserRepository
    {
        bool Create(User user);
        User GetUser(int id);
    }
}