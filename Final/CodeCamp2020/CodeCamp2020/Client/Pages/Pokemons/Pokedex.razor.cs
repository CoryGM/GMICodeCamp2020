using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

using CodeCamp2020.Client.Http;
using CodeCamp2020.Core.Extensions;
using CodeCamp2020.Shared.Pages.Pokedex;

namespace CodeCamp2020.Client.Pages.Pokemons
{
    public partial class Pokedex : ComponentBase
    {

        [Inject]
        private IHttpClientFactory _httpClientFactory { get; set; }

        private bool _formDisabled = false;
        private ViewModel _viewModel = new ViewModel();
        private SearchModel _searchModel = new SearchModel();
        private List<string> _errors = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync().ConfigureAwait(false);
        }

        private async Task OnSearchFormSubmittedAsync()
        {
            await GetViewModelAsync().ConfigureAwait(false);
        }

        private void OnResetSearchButtonClicked()
        {
            _searchModel = new SearchModel();
            _errors.Clear();
            _viewModel.Entities.Clear();
        }

        private async Task GetViewModelAsync()
        {
            _formDisabled = true;
            _errors.Clear();

            var baseUri = $"pages-api/pokedex";
            var queryDictionary = GetQueryParameterDictionary();
            var uri = QueryHelpers.AddQueryString(baseUri, queryDictionary);
            var viewModel = default(ViewModel);
            var httpClient = CreateHttpClient();

            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                viewModel = await response.Content.ReadAsJsonAsync<ViewModel>().ConfigureAwait(false);
            }
            else
            {
                viewModel = new ViewModel();

                if (response.StatusCode != HttpStatusCode.NotFound)
                {
                    _viewModel.AddError("Error in service call to search Pokemon.");
                }
            }

            _viewModel = viewModel;
            _errors.AddRange(_viewModel.Errors);

            _formDisabled = false;
        }

        private Dictionary<string, string> GetQueryParameterDictionary()
        {
            var searchModelDictionary = _searchModel.ToDictionaryString();
            var queryParametersDictionary = new Dictionary<string, string>(searchModelDictionary.Where(x => !String.IsNullOrWhiteSpace(x.Value)));

            return queryParametersDictionary;
        }

        private HttpClient CreateHttpClient()
        {
            return _httpClientFactory.CreateClient(HttpClientNames.Anonymous);
        }
    }
}
