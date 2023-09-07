using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OldCarShowroom.Api.Models;
using OldCarShowroom.Service.Services.Interfaces;
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
        private readonly IClientService _clientService;

        public AuthController(IConfiguration config, IClientService clientService)
        {
            _config = config;
            _clientService = clientService;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] string email, [FromForm] string password)
        {
            var userLogin = new UserLogin
            {
                Email = email,
                Password = password
            };
            var user = await Authenticate(userLogin);

            if (user is not null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }

            return Unauthorized("Wrong user name or password");
        }

        private async Task<User?> Authenticate(UserLogin userLogin)
        {
            var client = await _clientService.Login(userLogin.Email, userLogin.Password);
            if (client is not null)
            {
                return new User
                {
                    Name = client.Name,
                    Email = client.Email,
                    Role = client.Role
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
