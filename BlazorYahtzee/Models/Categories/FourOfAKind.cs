using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Categories
{
    public class FourOfAKind : ICategory
    {
        public string Name { get; } = "4 of a kind";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(ThreeOfAKind)),
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(FullHouse)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.Dice.HasAnyFourOfAKind();
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOfAKind(4);
        }
    }
}