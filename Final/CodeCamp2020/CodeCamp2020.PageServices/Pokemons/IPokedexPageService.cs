using System;
using System.Threading.Tasks;

using CodeCamp2020.Shared.Pages.Pokedex;

namespace CodeCamp2020.PageServices.Pokemons
{
    public interface IPokedexPageService
    {
        Task<ViewModel> GetViewModelAsync(string searchTerm, int? page, int? pageSize);
    }
}