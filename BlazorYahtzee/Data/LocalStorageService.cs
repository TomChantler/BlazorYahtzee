using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using BlazorYahtzee.Models;

namespace BlazorYahtzee.Data
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _jSRuntime;

        private const string ScoresKey = "Scores";

        public LocalStorageService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async Task AddScoresAsync(IEnumerable<Score> scores)
        {
            var data = JsonSerializer.Serialize(scores);
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem", ScoresKey, data).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Score>> GetScoresAsync()
        {
            var data = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", ScoresKey).ConfigureAwait(false);
            return data == null ? new List<Score>() : JsonSerializer.Deserialize<IEnumerable<Score>>(data);
        }
    }
}