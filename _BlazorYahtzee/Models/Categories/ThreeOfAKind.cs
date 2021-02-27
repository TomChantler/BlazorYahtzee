using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Categories
{
    public class ThreeOfAKind : ICategory
    {
        public string Name { get; } = "3 of a kind";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(TwoPair)),
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(FourOfAKind)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.Dice.HasAnyThreeOfAKind();
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOfAKind(3);
        }
    }
}