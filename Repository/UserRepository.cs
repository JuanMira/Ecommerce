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

        public bool Create(User user)
        {
            var userFound = _ctx.Users.Add(user);
            Console.WriteLine(user.ToString());
            try
            {
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;

        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}