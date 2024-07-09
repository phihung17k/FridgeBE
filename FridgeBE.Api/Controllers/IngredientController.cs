using FridgeBE.Core.Exceptions;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<IReadOnlyList<IngredientModel>>> GetAll()
        {
            IReadOnlyList<IngredientModel> results = await _service.GetAll();
            return Ok(results);
        }

        // GET api/<IngredientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientModel>> GetById(Guid id)
        {
            IngredientModel? ingredientModel = await _service.GetDetailIngredient(id);

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

            //if (ingredientRequest == null)
            //{
            //    return BadRequest();
            //}

            IngredientModel? ingredient = await _service.CreateIngredient(ingredientRequest);

            return Ok(ingredient);
        }

        // PUT api/<IngredientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(Guid id, [FromForm] IngredientUpdateRequest ingredientUpdateRequest)
        {
            if (ingredientUpdateRequest == null)
                return BadRequest();

            IngredientModel ingredient = await _service.UpdateIngredient(id, ingredientUpdateRequest);

            return Ok(ingredient);
        }

        // DELETE api/<IngredientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            IngredientModel? ingredient = await _service.DeleteIngredient(id);

            return Ok(ingredient);
        }
    }
}
