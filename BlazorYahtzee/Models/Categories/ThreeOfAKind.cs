namespace BlazorYahtzee.Models.Categories
{
    public class ThreeOfAKind : ICategory
    {
        public string Name { get; } = "3 of a kind";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBeClaimedBy(Player player)
        {
            return player.Dice.HasAnyThreeOfAKind();
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOfAKind(3);
        }
    }
}