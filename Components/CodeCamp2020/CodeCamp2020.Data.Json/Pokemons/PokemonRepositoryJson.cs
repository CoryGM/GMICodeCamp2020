using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using CodeCamp2020.Data.Models;

namespace CodeCamp2020.Data.Json.Pokemons
{
    public class PokemonRepositoryJson : IPokemonRepository
    {
        private List<PokemonJson> _data = new List<PokemonJson>();

        public PokemonRepositoryJson()
        {
            LoadData();
        }

        public async Task<Pokemon> GetAsync(string id)
        {
            var entityJson = _data.FirstOrDefault(x => x.Id == id);
            var entity = DataMapperJson.Mapper.Map<PokemonJson, Pokemon>(entityJson);

            return entity;
        }

        public async Task<IEnumerable<Pokemon>> GetAllAsync()
        {
            var entities = DataMapperJson.Mapper.Map<IEnumerable<PokemonJson>, Pokemon[]>(_data);
            return entities;
        }

        public async Task<IEnumerable<Pokemon>> SearchAsync(string searchTerm)
        {
            var results = await SearchAsync(searchTerm, 1, 0).ConfigureAwait(false);
            return results;
        }

        public async Task<IEnumerable<Pokemon>> SearchAsync(string searchTerm,
                                                            int? page,
                                                            int? pageSize)
        {
            if (!page.HasValue ||
                page < 1)
                page = 1;

            if (!pageSize.HasValue ||
                pageSize < 0)
                pageSize = 0;

            var query = _data.OrderBy(x => x.Name)
                             .ThenBy(x => x.Id)
                             .AsQueryable();

            if (!String.IsNullOrWhiteSpace(searchTerm))
                query = query.Where(x => x.Id == searchTerm ||
                                         x.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

            if (pageSize > 0)
            {
                var skip = (page.Value - 1) * pageSize.Value;
                query = query.Skip(skip).Take(pageSize.Value);
            }

            var entitiesJson = query.ToArray();
            var entities = DataMapperJson.Mapper.Map<IEnumerable<PokemonJson>, Pokemon[]>(entitiesJson);

            return entities;
        }

        private void LoadData()
        {
            using (StreamReader r = new StreamReader(@"..\..\..\..\data\pokedex.json"))
            {
                var json = r.ReadToEnd();
                _data = JsonConvert.DeserializeObject<List<PokemonJson>>(json);
            }
        }
    }
}
