namespace BlazorYahtzee.Models.Categories
{
    public class FullHouse : ICategory
    {
        public string Name { get; } = "Full House";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBeClaimedBy(Player player)
        {
            return player.Dice.HasFullHouse();
        }

        public int PointsFor(Player player)
        {
            return player.HasForcedPlay || player.Dice.HasFullHouse() ? 25 : 0;
        }
    }
}