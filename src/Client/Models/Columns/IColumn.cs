namespace BlazorYahtzee.Models.Columns
{
    public interface IColumn
    {
        ColumnType Type { get; }
        string IconCssClassName { get; }
    }
}
