using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using CodeCamp2020.Shared.Models;

namespace CodeCamp2020.Data
{
    public class PokemonRepository : IPokemonRepository
    {
        private List<Pokemon> _data = new List<Pokemon>();

        public PokemonRepository()
        {
            LoadData();
        }

        public async Task<Pokemon> GetAsync(string id)
        {
            var entity = _data.FirstOrDefault(x => x.Id == id);

            return entity;
        }

        public async Task<IEnumerable<Pokemon>> GetAllAsync()
        {
            return _data;
        }

        private void LoadData()
        {
            using (StreamReader r = new StreamReader(@"..\..\..\..\data\pokedex.json"))
            {
                var json = r.ReadToEnd();
                _data.AddRange(JsonConvert.DeserializeObject<List<Pokemon>>(json));
            }
        }
    }
}
