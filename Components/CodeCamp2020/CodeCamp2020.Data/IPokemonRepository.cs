using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CodeCamp2020.Data.Models;

namespace CodeCamp2020.Data
{
    public interface IPokemonRepository
    {
        Task<Pokemon> GetAsync(string id);
        Task<IEnumerable<Pokemon>> GetAllAsync();
        Task<IEnumerable<Pokemon>> SearchAsync(string searchTerm);
        Task<IEnumerable<Pokemon>> SearchAsync(string searchTerm, int? page, int? pageSize);
    }
}