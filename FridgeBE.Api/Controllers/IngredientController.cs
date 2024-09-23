using FridgeBE.Api.Authorization;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using static FridgeBE.Api.Constants.PermissionConstants;

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
        [HttpGet("all")]
        //[Permission(View.AllIngredients, Edit.Ingredient)]
        public async Task<ActionResult<IReadOnlyList<IngredientModel>>> GetAll()
        {
            IReadOnlyList<IngredientModel> results = await _service.GetAll();
            return Ok(results);
        }

        // GET: api/<IngredientController>
        [HttpGet]
        //[Permission(View.AllIngredients, Edit.Ingredient)]
        public async Task<ActionResult<Pagination<IngredientModel>>> GetPagingIngredientList(int pageIndex = 1, int pageSize = 10)
        {
            Pagination<IngredientModel> results = await _service.GetPagingIngredientList(pageIndex, pageSize);
            return Ok(results);
        }

        // GET api/<IngredientController>/5
        [HttpGet("{id}")]
        //[Permission(View.AllIngredients)]
        public async Task<ActionResult<IngredientModel>> GetById(Guid id)
        {
            IngredientModel? ingredientModel = await _service.GetDetailIngredient(id);

            return Ok(ingredientModel);
        }

        // POST api/<IngredientController>
        [HttpPost]
        //[Permission(View.AllIngredients, Edit.Ingredient)]
        public async Task<IActionResult> CreateIngredient([FromForm] IngredientCreationRequest ingredientRequest)
        {
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