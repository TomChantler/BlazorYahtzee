using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorYahtzee.Models;

namespace BlazorYahtzee.Services
{
    public interface IScoreService
    {
        Task AddScoreAsync(Player player);
        Task<IEnumerable<Score>> GetScoresAsync();
    }
}