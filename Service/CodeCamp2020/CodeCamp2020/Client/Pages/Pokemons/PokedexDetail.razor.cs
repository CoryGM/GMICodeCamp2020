using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using CodeCamp2020.Shared.Pages.PokedexDetail;
using CodeCamp2020.Core.Extensions;
using CodeCamp2020.Client.Http;

namespace CodeCamp2020.Client.Pages.Pokemons
{
    public partial class PokedexDetail : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private IHttpClientFactory _httpClientFactory { get; set; }

        private ViewModel _viewModel = new ViewModel();
        private string _pageTitle = "Retrieving...";
        private List<string> _errors = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync().ConfigureAwait(false);
            await GetViewModelAsync().ConfigureAwait(false);
        }

        private async Task GetViewModelAsync()
        {
            _errors.Clear();
            var uri = $"pages-api/pokedex-detail/{Id}";
            var viewModel = default(ViewModel);
            var httpClient = CreateHttpClient();
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                viewModel = await response.Content.ReadAsJsonAsync<ViewModel>().ConfigureAwait(false);
                _pageTitle = $"{viewModel.Entity.Name} #{viewModel.Entity.Id}";
                _errors.AddRange(_viewModel.Errors);
            }
            else
            {
                viewModel = new ViewModel();

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _pageTitle = "Not Found";
                    _errors.Add($"No Pokemon with ID '{Id}' were found.");
                }
                else
                {
                    _pageTitle = "Error";
                    _errors.Add("Error retrieving the Pokemon");
                }
            }

            _viewModel = viewModel;
        }

        private HttpClient CreateHttpClient()
        {
            return _httpClientFactory.CreateClient(HttpClientNames.Anonymous);
        }
    }
}
