using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Categories
{
    public class LargeStraight : ICategory
    {
        public string Name { get; } = "Large Straight";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(SmallStraight)),
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(Yahtzee)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.HasForcedPlay || player.Dice.HasLargeStraight();
        }

        public int PointsFor(Player player)
        {
            return player.HasForcedPlay || player.Dice.HasLargeStraight() ? 40 : 0;
        }
    }
}