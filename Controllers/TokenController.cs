using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PayrollAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PayrollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly PayrollContext _context;
        public IConfiguration _configuration;

        public TokenController(IConfiguration config, PayrollContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User _userData)
        {
            if (_userData != null && _userData.UserEmail != null && _userData.UserPassword != null)
            {
                var user = await GetUser(_userData.UserEmail, _userData.UserPassword);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim("UserEmail", user.UserEmail),
                        new Claim("FirstName", user.FirstName),
                        new Claim("MiddleName", user.MiddleName),
                        new Claim("LastName", user.LastName),
                        new Claim("UserPassword", user.UserPassword),
                        new Claim("UserPhone", user.UserPhone)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<User> GetUser(string email, string password)
        {
            return await _context.users.FirstOrDefaultAsync(u => u.UserEmail == email && u.UserPassword == password);
        }
    }
}
