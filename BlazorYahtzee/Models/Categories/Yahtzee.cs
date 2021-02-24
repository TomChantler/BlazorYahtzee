namespace BlazorYahtzee.Models.Categories
{
    public class Yahtzee : ICategory
    {
        public string Name { get; } = "Yahtzee";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBeClaimedBy(Player player)
        {
            return player.Dice.HasYahtzee();
        }

        public int PointsFor(Player player)
        {
            return player.Dice.HasYahtzee() ? 50 : 0;
        }
    }
}