namespace BlazorYahtzee.Models.Columns
{
    public class Down : IColumn
    {
        public ColumnType Type { get; } = ColumnType.Down;
        public string IconCssClassName { get; } = "far fa-arrow-alt-circle-down";
    }
}