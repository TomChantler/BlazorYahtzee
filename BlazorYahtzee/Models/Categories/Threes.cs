namespace BlazorYahtzee.Models.Categories
{
    public class Threes : ICategory
    {
        public string Name { get; } = "Threes";
        public SectionType Section { get; } = SectionType.Upper;

        public bool CanBeClaimedBy(Player player)
        {
            return player.Dice.HasThreeOfAKind(3);
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOf(3);
        }
    }
}