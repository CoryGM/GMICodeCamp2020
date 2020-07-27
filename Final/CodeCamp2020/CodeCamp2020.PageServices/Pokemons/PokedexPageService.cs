using System;
using System.Linq;
using System.Threading.Tasks;

using CodeCamp2020.Data;
using CodeCamp2020.Shared.Pages.Pokedex;

namespace CodeCamp2020.PageServices.Pokemons
{
    public class PokedexPageService : IPokedexPageService
    {
        private readonly IPokemonRepository _repository;

        public PokedexPageService(IPokemonRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ViewModel> GetViewModelAsync(string searchTerm, int? page, int? pageSize)
        {
            var viewModel = new ViewModel();

            var entities = await _repository.SearchAsync(searchTerm, page, pageSize).ConfigureAwait(false);

            viewModel.Entities.AddRange(entities.Select(x => new ViewModelEntity()
            {
                Id = x.Id,
                Attack = x.Attack,
                Category = x.Category,
                Defense = x.Defense,
                HitPoints = x.HitPoints,
                Name = x.Name,
                SpecialAttack = x.SpecialAttack,
                SpecialDefense = x.SpecialDefense,
                Speed = x.Speed,
                Type1 = x.Type1,
                Type2 = x.Type2
            }));

            if (!String.IsNullOrWhiteSpace(searchTerm) && searchTerm.Equals("errors"))
                AddErrors(viewModel);

            return viewModel;
        }

        private void AddErrors(ViewModel viewModel)
        {
            viewModel.AddError("This is the first error.");
            viewModel.AddError("This is the second error.");
        }
    }
}
