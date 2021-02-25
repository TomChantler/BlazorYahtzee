namespace BlazorYahtzee.Models.Categories
{
    public interface ICategory
    {
        string Name { get; }
        SectionType Section { get; }
        bool CanBePlayed(Player player, ColumnType type);
        bool CanBeClaimedInFull(Player player);
        int PointsFor(Player player);
    }
}