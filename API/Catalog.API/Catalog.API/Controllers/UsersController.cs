using Catalog.API.Models;
using Catalog.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
               var user = userService.Validate(model.UserName, model.Password);
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.UniqueName , user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email , user.Email),
                        new Claim(ClaimTypes.Role , user.Role)
                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                    var token = new JwtSecurityToken(
                        issuer: "http://www.kodluyoruz.com",
                        audience: "http://client.kodluyoruz.com",
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                        );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                return Unauthorized();
            }
            return BadRequest(ModelState);
        }
    }
}
