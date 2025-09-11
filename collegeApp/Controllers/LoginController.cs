using collegeApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace collegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Enter a valid username or password" });
            }
            else if (model.Username == "Raja" && model.Password == "1234")
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                    new Claim("role", "Admin")
                };

                //var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("JWTSecret"));
                byte[] key=null;
                string issuer = null;
                string audience = null;


                if (model.Policy == "Google")
                {
                    issuer= _config.GetValue<string>("GoogleAIssuer");
                    audience= _config.GetValue<string>("GoogleAudience");
                    key = Encoding.ASCII.GetBytes(_config.GetValue<string>("JWTSecretGoogle"));
                }else if(model.Policy == "Microsoft")
                {
                    issuer = _config.GetValue<string>("MicrosoftIssuer");
                    audience = _config.GetValue<string>("MicrosoftAudience");
                    key = Encoding.ASCII.GetBytes(_config.GetValue<string>("JWTSecretMicroshoft"));
                }else if (model.Policy == "Local")
                {
                    issuer = _config.GetValue<string>("LocalIssuer");
                    audience = _config.GetValue<string>("LocalAudience");
                    key = Encoding.ASCII.GetBytes(_config.GetValue<string>("JWTSecretLocal"));
                }

                var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            else
            {
                return Unauthorized(new { message = "User not valid" }); // ✅ fixed
            }
        }
    }
}
