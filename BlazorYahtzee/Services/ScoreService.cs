using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorYahtzee.Data;
using BlazorYahtzee.Models;

namespace BlazorYahtzee.Services
{
    public class ScoreService : IScoreService
    {
        private readonly ILocalStorageService _localStorageService;

        public ScoreService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task AddScoreAsync(Player player)
        {
            var data = await _localStorageService.GetScoresAsync();

            var scores = data.ToList();
            scores.Add(new Score(player.Plays.TotalScore()));

            await _localStorageService.AddScoresAsync(scores);
        }

        public async Task<IEnumerable<Score>> GetScoresAsync()
        {
            return await _localStorageService.GetScoresAsync();
        }
    }
}