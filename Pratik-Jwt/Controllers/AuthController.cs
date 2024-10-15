using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pratik_Jwt.Data;
using Pratik_Jwt.ViewModels;

namespace Pratik_Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtDbContext _jwtContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;

        public AuthController(UserManager<IdentityUser> userManager, JwtDbContext JwtContext, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _jwtContext = JwtContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = configuration;
            
        }
        [Authorize]
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(new { message = "Kullanıcılar getirildi" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(new { message = "Kayıt Başarılı" });
                }
                return BadRequest(new { errors = result.Errors.Select(e => e.Description) });

            }
            return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var token = Helper.GenerateJwtToken(model.Email, _config["Jwt:key"], _config["Jwt:Issuer "], _config["Jwt:Audience"]);
                    return Ok(new { message = "Giriş Başarılı",token = token });
                }
                else
                {
                    return Unauthorized(new { message = "Kullanıcı adı veya şifre hatalı" });
                }
            }
            return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

    }
  
}
