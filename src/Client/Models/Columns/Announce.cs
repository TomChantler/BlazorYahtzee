namespace BlazorYahtzee.Models.Columns
{
    public class Announce : IColumn
    {
        public ColumnType Type { get; } = ColumnType.Announce;
        public string IconCssClassName { get; } = "fas fa-bullhorn";
    }
}