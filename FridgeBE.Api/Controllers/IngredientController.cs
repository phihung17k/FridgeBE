using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models;
using FridgeBE.Core.Models.RequestModels;
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
        public async Task<ActionResult<IReadOnlyList<IngredientModel>>> Get()
        {
            IReadOnlyList<IngredientModel> results = await _service.GetAll();
            return Ok(results);
        }

        // GET api/<IngredientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientModel>> Get(Guid id)
        {
            IngredientModel? ingredientModel = await _service.GetDetailIngredient(id);
            if (ingredientModel == null)
                return NotFound();

            return Ok(ingredientModel);
        }

        // POST api/<IngredientController>
        [HttpPost]
        public async Task<IActionResult> CreateIngredient([FromForm] IngredientCreationRequest ingredientRequest)
        {
            // modelstate valid, annotation return error automatically if invalid
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (ingredientRequest == null)
            {
                return BadRequest();
            }

            IngredientModel? ingredient = await _service.CreateIngredient(ingredientRequest);

            return Ok(ingredient);
        }

        // PUT api/<IngredientController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] IngredientUpdateRequest ingredientUpdateRequest)
        {

        }

        // DELETE api/<IngredientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
