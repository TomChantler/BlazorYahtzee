using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Categories
{
    public class SmallStraight : ICategory
    {
        public string Name { get; } = "Small Straight";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(FullHouse)),
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(LargeStraight)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.HasForcedPlay || player.Dice.HasSmallStraight();
        }

        public int PointsFor(Player player)
        {
            return player.HasForcedPlay || player.Dice.HasSmallStraight() ? 30 : 0;
        }
    }
}