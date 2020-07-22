using CodeCamp2020.Shared.Pages.Pokedex;
using System.Threading.Tasks;

namespace CodeCamp2020.PageServices.Pokemons
{
    public interface IPokedexPageService
    {
        Task<ViewModel> GetViewModelAsync(string searchTerm, int? page, int? pageSize);
    }
}