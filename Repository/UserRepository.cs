using Ecommerce.Data;
using Ecommerce.Models;

namespace Ecommerce.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _ctx;

        public UserRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> Create(User user)
        {
            var userFound = await _ctx.User.AddAsync(user);
            if (userFound != null)
                return userFound.Entity;
            return null;
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}