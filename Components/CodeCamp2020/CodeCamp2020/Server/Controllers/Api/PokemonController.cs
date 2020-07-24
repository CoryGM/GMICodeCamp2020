using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CodeCamp2020.Data;
using CodeCamp2020.Data.Models;

namespace CodeCamp2020.Server.Controllers.Api
{
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _repository;
        private readonly ILogger _logger;

        public PokemonController(IPokemonRepository repository,
                                 ILogger<PokemonController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                var baseMsg = $"Error retrieving Pokemon \"{id}\".";
                _logger.LogError(ex, $"{baseMsg} Check the log for details.");
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
                var baseMsg = $"Error retrieving Pokemon.";
                _logger.LogError(ex, $"{baseMsg} Check the log for details.");
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
                var baseMsg = $"Error searching Pokemon.";
                _logger.LogError(ex, $"{baseMsg} Check the log for details.");
            }

            if (entities == null)
                entities = new List<Pokemon>();

            return Ok(entities);
        }
    }
}
