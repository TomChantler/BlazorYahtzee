namespace BlazorYahtzee.Models.Categories
{
    public class Twos : ICategory
    {
        public string Name { get; } = "Twos";
        public SectionType Section { get; } = SectionType.Upper;

        public bool CanBeClaimedBy(Player player)
        {
            return player.Dice.HasThreeOfAKind(2);
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOf(2);
        }
    }
}