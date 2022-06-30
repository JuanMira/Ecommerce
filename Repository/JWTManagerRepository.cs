using System.Diagnostics;
using System.Text;
using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Ecommerce.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _ctx;

        public JWTManagerRepository(IConfiguration configuration, ApplicationDbContext ctx)
        {
            _configuration = configuration;
            _ctx = ctx;
        }

        public Tokens Authenticate(string username, string password)
        {
            if (username == null && password == null)
                throw new Exception("User not found");

            var userFound = _ctx.Users.Join(
                _ctx.Roles,
                user => user.RoleId,
                role => role.Id,
                (user, role) => new { User = user, Role = role })
            .Where(userRole => userRole.Role.Id == userRole.User.RoleId && userRole.User.Username == username).FirstOrDefault();

            if (userFound == null)
                throw new Exception("Can't find user");


            // validate password
            var isValid = Helpers.PasswordHelper.Compare(password, userFound?.User.Password);

            if (!isValid)
                throw new Exception("Password didn't match");

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim("user_id", userFound.User.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFound.User.Username),
                    new Claim(ClaimTypes.Email, userFound.User.Email),
                    new Claim(ClaimTypes.Role, userFound.Role.RoleName),
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) }; ;
        }
    }
}