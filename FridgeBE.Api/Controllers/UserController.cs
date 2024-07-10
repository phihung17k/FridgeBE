using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeBE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult CreateUser()
        {
            return Ok();
        }
    }
}