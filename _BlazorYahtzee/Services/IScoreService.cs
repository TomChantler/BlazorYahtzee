using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorYahtzee.Models;
using BlazorYahtzee.Models.Modes;

namespace BlazorYahtzee.Services
{
    public interface IScoreService
    {
        Task AddScoreAsync(Game game);
        Task<IEnumerable<Score>> GetScoresAsync(ModeType modeType);
    }
}