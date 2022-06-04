using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {


        private readonly IJWTManagerRepository _jwt;
        private readonly IUserRepository _uRepository;

        public AccountController(IJWTManagerRepository jwt, IUserRepository uRepository)
        {
            _jwt = jwt;
            _uRepository = uRepository;
        }

        [HttpPost("/Login")]
        public IActionResult Login(string username, string password)
        {
            var token = _jwt.Authenticate(username, password);
            return token != null ? Ok(token) : NotFound(new { Message = "Can't get credential try again" });
        }

        [HttpPost("/Register")]
        public IActionResult Register(User user)
        {
            user.Password = Helpers.PasswordHelper.EncryptPassword(user?.Password);
            var userFound = _uRepository.Create(user);
            return userFound != null ? Ok(new { Message = "User created successfully" }) : NoContent();
        }
    }
}