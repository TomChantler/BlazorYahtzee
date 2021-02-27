using BlazorYahtzee.Models.Categories;

namespace BlazorYahtzee.Models
{
    public class Play
    {
        public ICategory Category { get; }
        public int Points { get; }

        public Play(ICategory category, int points)
        {
            Category = category;
            Points = points;
        }
    }
}