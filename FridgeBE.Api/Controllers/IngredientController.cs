using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<ActionResult<IngredientModel>> Get()
        {
            IngredientModel? ingredientModel = await _service.GetDetailIngredient(Guid.Parse("6B44F92C-8866-4AF3-9CBB-73497837002E"));
            if(ingredientModel == null)
            {
                return NotFound();
            }

            return Ok(ingredientModel);
        }

        // GET api/<IngredientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
