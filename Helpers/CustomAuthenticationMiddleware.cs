using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Ecommerce.Repository;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Helpers
{
    public class CustomAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly string _key;

        public CustomAuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
            _key = _configuration.GetValue<string>("JWT:Key");
        }

        public async Task Invoke(HttpContext context, IUserRepository userRepo)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null) attachUserToContext(context, userRepo, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserRepository userRepo, string token)
        {
            try
            {
                var tokenHanlder = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_key);
                tokenHanlder.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                string UserID = jwtToken.Claims.First(x => x.Type == "user_id").Value;
                context.Items["User"] = userRepo.GetUser(int.Parse(UserID));
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}