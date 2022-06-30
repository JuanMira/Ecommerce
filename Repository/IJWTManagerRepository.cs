using Ecommerce.Models;

namespace Ecommerce.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(string username, string password);
    }
}