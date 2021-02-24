namespace BlazorYahtzee.Models.Categories
{
    public class Aces : ICategory
    {
        public string Name { get; } = "Aces";
        public SectionType Section { get; } = SectionType.Upper;

        public bool CanBeClaimedBy(Player player)
        {
            return player.Dice.HasThreeOfAKind(1);
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOf(1);
        }
    }
}