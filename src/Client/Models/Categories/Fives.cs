using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Categories
{
    public class Fives : ICategory
    {
        public string Name { get; } = "Fives";
        public SectionType Section { get; } = SectionType.Upper;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(Fours)),
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(Sixes)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.Dice.HasThreeOfAKind(5);
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOf(5);
        }
    }
}