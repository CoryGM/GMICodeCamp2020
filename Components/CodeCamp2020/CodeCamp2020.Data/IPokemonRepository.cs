using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CodeCamp2020.Shared.Models;

namespace CodeCamp2020.Data
{
    public interface IPokemonRepository
    {
        Task<Pokemon> GetAsync(string id);
        Task<IEnumerable<Pokemon>> GetAllAsync();
    }
}