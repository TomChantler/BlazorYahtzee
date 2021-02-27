using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Categories
{
    public class Yahtzee : ICategory
    {
        public string Name { get; } = "Yahtzee";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(LargeStraight)),
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(Chance)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.Dice.HasYahtzee();
        }

        public int PointsFor(Player player)
        {
            return player.Dice.HasYahtzee() ? 50 : 0;
        }
    }
}