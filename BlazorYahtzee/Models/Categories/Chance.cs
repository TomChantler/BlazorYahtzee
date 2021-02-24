namespace BlazorYahtzee.Models.Categories
{
    public class Chance : ICategory
    {
        public string Name { get; } = "Chance";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBeClaimedBy(Player player)
        {
            return true;
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOfAll();
        }
    }
}