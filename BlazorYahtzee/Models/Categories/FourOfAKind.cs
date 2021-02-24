namespace BlazorYahtzee.Models.Categories
{
    public class FourOfAKind : ICategory
    {
        public string Name { get; } = "4 of a kind";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBeClaimedBy(Player player)
        {
            return player.Dice.HasAnyFourOfAKind();
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOfAKind(4);
        }
    }
}