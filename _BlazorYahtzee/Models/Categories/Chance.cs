using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Categories
{
    public class Chance : ICategory
    {
        public string Name { get; } = "Chance";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(Yahtzee)),
                ColumnType.Up => player.Plays(ColumnType.Down).HasPlay(typeof(Chance)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return true;
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOfAll();
        }
    }
}