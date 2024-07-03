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

        [HttpPost]
        public async Task<ActionResult<UserAccountModel>> Register([FromBody] UserRegisterRequest request)
        {
            UserAccountModel result = await _userService.CreateUser(request);

            if (result == null)
                return BadRequest("");

            return Ok(result);
        }
    }
}