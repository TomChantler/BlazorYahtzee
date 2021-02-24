using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorYahtzee.Models.Categories;

namespace BlazorYahtzee.Services
{
    public class CategoryService : ICategoryService
    {
        public async Task<IEnumerable<ICategory>> GetCategoriesAsync()
        {
            return await Task.FromResult(new List<ICategory>
            {
                new Aces(),
                new Twos(),
                new Threes(),
                new Fours(),
                new Fives(),
                new Sixes(),
                new ThreeOfAKind(),
                new FourOfAKind(),
                new FullHouse(),
                new SmallStraight(),
                new LargeStraight(),
                new Yahtzee(),
                new Chance()
            });
        }
    }
}