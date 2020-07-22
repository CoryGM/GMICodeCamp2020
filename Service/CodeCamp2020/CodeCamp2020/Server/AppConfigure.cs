using System;

using Microsoft.Extensions.DependencyInjection;

using CodeCamp2020.Data;
using CodeCamp2020.Data.Json;
using CodeCamp2020.Data.Json.Pokemons;
using CodeCamp2020.PageServices.Pokemons;

namespace CodeCamp2020.Server
{
    public class AppConfigure
    {
        public void Initialize(IServiceCollection services)
        {
            DataMapperJson.InitializeMapper();

            if (services != null)
            {
                services.AddSingleton<IPokemonRepository, PokemonRepositoryJson>();

                //  Page services
                services.AddTransient<IPokedexPageService, PokedexPageService>();
            }
        }
    }
}
