using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CodeCamp2020.PageServices.Pokemons;
using CodeCamp2020.Shared.Pages.Pokedex;

namespace CodeCamp2020.Server.Controllers.PageApi
{
    [ApiController]
    [Route("pages-api/pokedex")]
    public class PokedexPageController : ControllerBase
    {
        private readonly IPokedexPageService _pageService;
        private readonly ILogger _logger;

        public PokedexPageController(IPokedexPageService pageService,
                                     ILogger<PokedexPageController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _pageService = pageService ?? throw new ArgumentNullException(nameof(pageService));
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ViewModel>> GetViewModelAsync([FromQuery]string searchTerm, 
                                                                     [FromQuery]int? page, 
                                                                     [FromQuery]int? pageSize)
        {
            var viewModel = default(ViewModel);

            try
            {
                viewModel = await _pageService.GetViewModelAsync(searchTerm, page, pageSize).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                viewModel = new ViewModel();
                var baseMsg = $"Error retrieving Pokemon.";
                _logger.LogError(ex, $"{baseMsg} Check the log for details.");
                viewModel.AddError(baseMsg);
            }

            if (viewModel == null)
                viewModel = new ViewModel();

            return Ok(viewModel);
        }
    }
}
