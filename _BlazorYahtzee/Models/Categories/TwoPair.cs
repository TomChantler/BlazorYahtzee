using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Categories
{
    public class TwoPair : ICategory
    {
        public string Name { get; } = "Two Pair";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(Pair)),
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(ThreeOfAKind)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.Dice.HasTwoPair();
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOfTwoPair();
        }
    }
}