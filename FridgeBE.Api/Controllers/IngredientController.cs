using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FridgeBE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        public IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

        // GET: api/<IngredientController>
        [HttpGet]
        public async Task<ActionResult<List<IngredientModel>>> Get()
        {
            
            return Ok();
        }

        // GET api/<IngredientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientModel>> Get(string id)
        {
            IngredientModel? ingredientModel = await _service.GetDetailIngredient(Guid.Parse(id));
            if (ingredientModel == null)
            {
                return NotFound();
            }

            return Ok(ingredientModel);
        }

        // POST api/<IngredientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<IngredientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IngredientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
