using System;
using System.Threading.Tasks;

using CodeCamp2020.Data;
using CodeCamp2020.Shared.Pages.PokedexDetail;

namespace CodeCamp2020.PageServices.Pokemons
{
    public class PokedexDetailPageService : IPokedexDetailPageService
    {
        private readonly IPokemonRepository _repository;

        public PokedexDetailPageService(IPokemonRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ViewModel> GetViewModelAsync(string id)
        {
            var viewModel = new ViewModel();

            var entity = await _repository.GetAsync(id).ConfigureAwait(false);

            if (entity != null)
            {
                viewModel.Entity = new ViewModelEntity()
                {
                    Id = entity.Id,
                    Abilities = entity.Abilities,
                    Attack = entity.Attack,
                    CaptureRate = entity.CaptureRate,
                    Category = entity.Category,
                    Defense = entity.Defense,
                    EggSteps = entity.EggSteps,
                    ExpGroup = entity.ExpGroup,
                    Height = entity.Height,
                    HitPoints = entity.HitPoints,
                    Name = entity.Name,
                    PictureUrl = $"https://assets.pokemon.com/assets/cms2/img/pokedex/full/{id}.png",
                    SpecialAttack = entity.SpecialAttack,
                    SpecialDefense = entity.SpecialDefense,
                    Speed = entity.Speed,
                    Type1 = entity.Type1,
                    Type2 = entity.Type2,
                    Weight = entity.Weight
                };
            }

            return viewModel;
        }
    }
}
