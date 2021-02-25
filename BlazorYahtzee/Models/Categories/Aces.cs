using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Categories
{
    public class Aces : ICategory
    {
        public string Name { get; } = "Aces";
        public SectionType Section { get; } = SectionType.Upper;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => true,
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(Twos)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.Dice.HasThreeOfAKind(1);
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOf(1);
        }
    }
}