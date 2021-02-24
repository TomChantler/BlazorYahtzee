namespace BlazorYahtzee.Models.Categories
{
    public class SmallStraight : ICategory
    {
        public string Name { get; } = "Small Straight";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBeClaimedBy(Player player)
        {
            return player.Dice.HasSmallStraight();
        }

        public int PointsFor(Player player)
        {
            return player.HasForcedPlay || player.Dice.HasSmallStraight() ? 30 : 0;
        }
    }
}