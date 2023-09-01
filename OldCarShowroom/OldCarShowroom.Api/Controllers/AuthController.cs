using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OldCarShowroom.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OldCarShowroom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }


        [HttpPost]
        public IActionResult GetToken([FromForm] string email, [FromForm] string password)
        {
            var userLogin = new UserLogin
            {
                Email = email,
                Password = password
            };
            var user = Authenticate(userLogin);

            if (user is not null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }

            return Unauthorized("User does not exist");
        }

        private User? Authenticate(UserLogin userLogin)
        {
            if (userLogin.Email == "email@gmail.com" && userLogin.Password == "123")
            {
                return new User
                {
                    Name = "duy",
                    Email = userLogin.Email,
                    Password = userLogin.Password,
                    Role = "user"
                };
            }
            return null;
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["JwtSettings:Issuer"],
                _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
