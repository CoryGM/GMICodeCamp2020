using System;

using AutoMapper;

using CodeCamp2020.Data.Json.Pokemons;
using CodeCamp2020.Data.Models;

namespace CodeCamp2020.Data.Json
{
    public class DataMapperJson
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                    InitializeMapper();

                return _mapper;
            }
        }

        public static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PokemonJson, Pokemon>();
            });

            config.AssertConfigurationIsValid();

            _mapper = config.CreateMapper();
        }
    }
}
