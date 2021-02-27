namespace BlazorYahtzee.Models.Columns
{
    public class Up : IColumn
    {
        public ColumnType Type { get; } = ColumnType.Up;
        public string IconCssClassName { get; } = "far fa-arrow-alt-circle-up";
    }
}