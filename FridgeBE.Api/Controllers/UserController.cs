using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeBE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser()
        {
            return Ok();
        }
    }
}