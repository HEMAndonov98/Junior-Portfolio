using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyChatRooms.API.Data.Models;

namespace MyChatRooms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ChatUser> _userManager;
        private readonly SignInManager<ChatUser> _signInManager;

        public AuthController(UserManager<ChatUser> userManager, SignInManager<ChatUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new ChatUser { UserName = request.Username, Email = request.Email };
            var result = await this._userManager.CreateAsync(user, request.Password);

            if (result.Succeeded) return Ok(new { message = "User registered successfuly" });

            return BadRequest(result.Errors);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await this._userManager.FindByNameAsync(request.Username);
            if (user == null) return Unauthorized("Invalid username or password");

            var result = await this._signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!result.Succeeded) return Unauthorized("Invalid username or password");


            var sessionKey = Guid.NewGuid().ToString();
            HttpContext.Session.SetString("SessionKey", sessionKey);

            var test = this.HttpContext.Session.GetString("SessionKey");


            Response.Cookies.Append("SessionKey", sessionKey, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(1)
            });


            return Ok(new { message = "User logged in successfuly" });
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await this._signInManager.SignOutAsync();
            return Ok(new { message = "User logged out successfuly" });
        }

        [HttpGet("protected-resource")]
        public IActionResult GetProtectedData()
        {
            var sessionKey = Request.Cookies["SessionKey"];

            if (string.IsNullOrEmpty(sessionKey) || sessionKey != HttpContext.Session.GetString("SessionKey"))
            {
                return Unauthorized(new { error = "Invalid or expired session" });
            }

            var user = HttpContext.User;

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), $"HttpContext could not find user in {nameof(AuthController)} -> {nameof(GetProtectedData)} -> Line 77");
            }

            var userDto = new UserDto() { Username = user.Identity?.Name! };

            return Ok(new { data = userDto });
        }

    }

    public class RegisterRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }

    public class LoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public class UserDto
    {
        public required string Username { get; set; }
    }
}
