namespace BlazorYahtzee.Models.Categories
{
    public interface ICategory
    {
        string Name { get; }
        SectionType Section { get; }
        bool CanBeClaimedBy(Player player);
        int PointsFor(Player player);
    }
}