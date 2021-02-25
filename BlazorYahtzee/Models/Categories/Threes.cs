namespace BlazorYahtzee.Models.Categories
{
    public class Threes : ICategory
    {
        public string Name { get; } = "Threes";
        public SectionType Section { get; } = SectionType.Upper;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(Twos)),
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(Fours)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.Dice.HasThreeOfAKind(3);
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOf(3);
        }
    }
}