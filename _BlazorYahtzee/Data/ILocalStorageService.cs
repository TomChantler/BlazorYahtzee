using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorYahtzee.Models;
using BlazorYahtzee.Models.Modes;

namespace BlazorYahtzee.Data
{
    public interface ILocalStorageService
    {
        Task AddScoresAsync(ModeType modeType, IEnumerable<Score> scores);
        Task<IEnumerable<Score>> GetScoresAsync(ModeType modeType);
    }
}