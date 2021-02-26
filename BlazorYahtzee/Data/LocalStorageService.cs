using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using BlazorYahtzee.Models;
using BlazorYahtzee.Models.Modes;

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

        public async Task AddScoresAsync(ModeType modeType, IEnumerable<Score> scores)
        {
            var data = JsonSerializer.Serialize(scores);
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem", Key(modeType), data).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Score>> GetScoresAsync(ModeType modeType)
        {
            var data = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", Key(modeType)).ConfigureAwait(false);
            return data == null ? new List<Score>() : JsonSerializer.Deserialize<IEnumerable<Score>>(data);
        }

        private static string Key(ModeType modeType) => modeType == ModeType.Standard ? ScoresKey : $"{ScoresKey}|{modeType}";
    }
}