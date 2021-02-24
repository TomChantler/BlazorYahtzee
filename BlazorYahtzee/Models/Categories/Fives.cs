namespace BlazorYahtzee.Models.Categories
{
    public class Fives : ICategory
    {
        public string Name { get; } = "Fives";
        public SectionType Section { get; } = SectionType.Upper;

        public bool CanBeClaimedBy(Player player)
        {
            return player.Dice.HasThreeOfAKind(5);
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOf(5);
        }
    }
}