using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FridgeBE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // GET: api/<CategoryController>
        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyList<CategoryResponseModel>>> GetAll()
        {
            IReadOnlyList<CategoryResponseModel> results = await _service.GetAll();
            return Ok(results);
        }
    }
}