using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CodeCamp2020.PageServices.Pokemons;
using CodeCamp2020.Shared.Pages.PokedexDetail;

namespace CodeCamp2020.Server.Controllers.PageApi
{
    [ApiController]
    [Route("pages-api/pokedex-detail")]
    public class PokedexDetailPageController : ControllerBase
    {
        private readonly IPokedexDetailPageService _pageService;
        private readonly ILogger _logger;

        public PokedexDetailPageController(IPokedexDetailPageService pageService,
                                     ILogger<PokedexDetailPageController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _pageService = pageService ?? throw new ArgumentNullException(nameof(pageService));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ViewModel>> GetViewModelAsync(string id)
        {
            var viewModel = default(ViewModel);

            try
            {
                viewModel = await _pageService.GetViewModelAsync(id).ConfigureAwait(false);
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
