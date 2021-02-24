namespace BlazorYahtzee.Models.Categories
{
    public class Sixes : ICategory
    {
        public string Name { get; } = "Sixes";
        public SectionType Section { get; } = SectionType.Upper;

        public bool CanBeClaimedBy(Player player)
        {
            return player.Dice.HasThreeOfAKind(6);
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOf(6);
        }
    }
}