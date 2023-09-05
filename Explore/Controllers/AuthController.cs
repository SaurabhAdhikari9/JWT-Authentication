using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Explore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("token")]
        public IActionResult  GetToken()
        {
            var claims = new[]
            {new Claim("hehe", "saurav")

            };

            var token = new JwtSecurityToken(
                issuer: "Orderwise",
                audience: "Orderwise",
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.BigEndianUnicode.GetBytes("Order Wise")),SecurityAlgorithms.HmacSha256 ),
                claims: claims
                );
                         

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
