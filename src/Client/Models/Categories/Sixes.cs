using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Categories
{
    public class Sixes : ICategory
    {
        public string Name { get; } = "Sixes";
        public SectionType Section { get; } = SectionType.Upper;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(Fives)),
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(Pair)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.Dice.HasThreeOfAKind(6);
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOf(6);
        }
    }
}