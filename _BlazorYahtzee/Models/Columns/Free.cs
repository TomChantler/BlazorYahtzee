namespace BlazorYahtzee.Models.Columns
{
    public class Free : IColumn
    {
        public ColumnType Type { get; } = ColumnType.Free;
        public string IconCssClassName { get; } = "far fa-smile";
    }
}