using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Categories
{
    public class Fours : ICategory
    {
        public string Name { get; } = "Fours";
        public SectionType Section { get; } = SectionType.Upper;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(Threes)),
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(Fives)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.Dice.HasThreeOfAKind(4);
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOf(4);
        }
    }
}