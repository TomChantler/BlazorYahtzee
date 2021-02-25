namespace BlazorYahtzee.Models.Categories
{
    public class Twos : ICategory
    {
        public string Name { get; } = "Twos";
        public SectionType Section { get; } = SectionType.Upper;

        public bool CanBePlayed(Player player, ColumnType type)
        {
            return type switch
            {
                ColumnType.Down => player.Plays(ColumnType.Down).HasPlay(typeof(Aces)),
                ColumnType.Up => player.Plays(ColumnType.Up).HasPlay(typeof(Threes)),
                _ => true
            };
        }

        public bool CanBeClaimedInFull(Player player)
        {
            return player.Dice.HasThreeOfAKind(2);
        }

        public int PointsFor(Player player)
        {
            return player.Dice.SumOf(2);
        }
    }
}