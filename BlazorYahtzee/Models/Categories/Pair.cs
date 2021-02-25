namespace BlazorYahtzee.Models.Categories
{
    public class Pair : ICategory
    {
        public string Name { get; } = "Pair";
        public SectionType Section { get; } = SectionType.Lower;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(Sixes)),
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(TwoPair)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.Dice.HasAnyPair();
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOfAKind(2);
        }
    }
}