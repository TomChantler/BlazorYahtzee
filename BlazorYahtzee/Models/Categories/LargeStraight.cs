namespace BlazorYahtzee.Models.Categories
{
    public class LargeStraight : ICategory
    {
        public string Name { get; } = "Large Straight";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBeClaimedBy(Player player)
        {
            return player.Dice.HasLargeStraight();
        }

        public int PointsFor(Player player)
        {
            return player.HasForcedPlay || player.Dice.HasLargeStraight() ? 40 : 0;
        }
    }
}