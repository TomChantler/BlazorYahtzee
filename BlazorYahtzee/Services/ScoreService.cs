using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorYahtzee.Data;
using BlazorYahtzee.Models;
using BlazorYahtzee.Models.Modes;

namespace BlazorYahtzee.Services
{
    public class ScoreService : IScoreService
    {
        private readonly ILocalStorageService _localStorageService;

        public ScoreService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task AddScoreAsync(Game game)
        {
            var data = await _localStorageService.GetScoresAsync(game.Mode.Type);

            var scores = data.ToList();
            scores.Add(new Score(game.Player.TotalScore()));

            await _localStorageService.AddScoresAsync(game.Mode.Type, scores);
        }

        public async Task<IEnumerable<Score>> GetScoresAsync(ModeType modeType)
        {
            return await _localStorageService.GetScoresAsync(modeType);
        }
    }
}