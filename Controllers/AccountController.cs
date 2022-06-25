using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

[ApiController]
[Route("/authentication")]
public class AccountController : ControllerBase
{
    private readonly IJWTManagerRepository _jwt;
    private readonly IUserRepository _uRepository;

    public AccountController(IJWTManagerRepository jwt, IUserRepository uRepository)
    {
        _jwt = jwt;
        _uRepository = uRepository;
    }

    [HttpGet]
    public string GetExample() => "Testing routes";

    [HttpPost]
    [Route("login")]
    public IActionResult Login(Login login)
    {
        var token = _jwt.Authenticate(login.Username, login.Password);
        return token != null ? Ok(token) : NotFound(new { Message = "Can't get credential try again" });
    }

    [HttpPost]
    [Route("register")]
    public IActionResult Register(User user)
    {
        Console.WriteLine("Posted");
        if (user is null)
        {
            return NotFound(new { Message = "User is empty" });
        }

        user.Password = Helpers.PasswordHelper.EncryptPassword(user?.Password);
        var userFound = _uRepository.Create(user);
        return userFound ? Ok(new { Message = "User created successfully" }) : NoContent();
    }
}
