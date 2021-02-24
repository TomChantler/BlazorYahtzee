namespace BlazorYahtzee.Models.Categories
{
    public class Fours : ICategory
    {
        public string Name { get; } = "Fours";
        public SectionType Section { get; } = SectionType.Upper;

        public bool CanBeClaimedBy(Player player)
        {
            return player.Dice.HasThreeOfAKind(4);
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOf(4);
        }
    }
}