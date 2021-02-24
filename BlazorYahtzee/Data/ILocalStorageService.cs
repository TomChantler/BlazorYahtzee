using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorYahtzee.Models;

namespace BlazorYahtzee.Data
{
    public interface ILocalStorageService
    {
        Task AddScoresAsync(IEnumerable<Score> scores);
        Task<IEnumerable<Score>> GetScoresAsync();
    }
}