using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebCoreApp.Data;
using WebCoreApp.Models;
using WebCoreApp.Models.ApiResponse;
using WebCoreApp.Models.User;

namespace WebCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly AppSetting _appSetting;
        public UserController(MyDbContext context, IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _context = context;
            _appSetting = optionsMonitor.CurrentValue;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginVM model)
        {
            var user = _context.Users.SingleOrDefault(p => p.UserName == model.UserName && p.Password == p.Password);
            if (user != null)
                return Ok(new ApiResponse 
                {
                    IsSuccess = true,
                    Message = "Login Success",
                    Data = GenerateToken(user),
                });
            else
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    Message = "Login fail",
                    Data = null,
                });
        }

        private string GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var sercetKeyBytes = Encoding.UTF8.GetBytes(_appSetting.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.FullName),

                    //Role


                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),

                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(sercetKeyBytes), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }

        // POST api/<User>
        [HttpPost]
        public IActionResult CreateNew(RegisterVM model)
        {
            try
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    Address = model.Address,
                    Email = model.Email,
                    FullName = model.FullName,
                };
                _context.Add(user);
                _context.SaveChanges();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


    }
}
