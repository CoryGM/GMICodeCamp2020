using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using CodeCamp2020.Data;
using CodeCamp2020.Data.Models;

namespace CodeCamp2020.Server.Controllers.Api
{
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _repository;

        public PokemonController(IPokemonRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Pokemon>> GetAsync(string id)
        {
            var entity = default(Pokemon);

            try
            {
                entity = await _repository.GetAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving Pokemon \"{id}\". Exception: {ex.Message}");
            }

            if (entity == null)
                return NotFound();
            else
                return Ok(entity);
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<Pokemon>> SearchAsync([FromQuery] string searchTerm,
                                                             [FromQuery] int? page,
                                                             [FromQuery] int? pageSize)
        {
            var entities = default(IEnumerable<Pokemon>);

            try
            {
                entities = await _repository.SearchAsync(searchTerm, page, pageSize).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving Pokemon. Exception: {ex.Message}");
            }

            if (entities == null)
                entities = new List<Pokemon>();

            return Ok(entities);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetAllAsync()
        {
            var entities = default(IEnumerable<Pokemon>);

            try
            {
                entities = await _repository.GetAllAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving Pokemon. Exception: {ex.Message}");
            }

            if (entities == null)
                entities = new List<Pokemon>();

            return Ok(entities);
        }
    }
}
