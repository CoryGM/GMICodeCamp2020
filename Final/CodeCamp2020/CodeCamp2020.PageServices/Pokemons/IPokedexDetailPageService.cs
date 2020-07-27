using System;
using System.Threading.Tasks;

using CodeCamp2020.Shared.Pages.PokedexDetail;

namespace CodeCamp2020.PageServices.Pokemons
{
    public interface IPokedexDetailPageService
    {
        Task<ViewModel> GetViewModelAsync(string id);
    }
}