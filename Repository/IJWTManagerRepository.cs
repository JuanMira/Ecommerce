using Ecommerce.Models;

namespace Ecommerce.Repository
{
    public interface IJWTManagerRepository
    {
        Task<Tokens> Authenticate(string username, string password);
    }
}