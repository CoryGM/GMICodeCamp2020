using System;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace CodeCamp2020.Core.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            string json = await content.ReadAsStringAsync().ConfigureAwait(false);
            T value = JsonConvert.DeserializeObject<T>(json);

            return value;
        }
    }
}
