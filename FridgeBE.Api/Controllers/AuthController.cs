using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace FridgeBE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponseModel>> Register([FromBody] UserRegisterRequest request)
        {
            RegisterResponseModel result = await _userService.CreateUser(request);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginRequest request)
        {
            LoginResponseModel result = await _userService.SignInByPassword(request);

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            RefreshTokenModel result = await _userService.RefreshToken(request);

            return Ok(result);
        }
    }
}