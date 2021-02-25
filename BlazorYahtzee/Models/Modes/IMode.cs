using System.Collections.Generic;
using BlazorYahtzee.Models.Categories;

namespace BlazorYahtzee.Models.Modes
{
    public interface IMode
    {
        ModeType Type { get; }
        ColumnType[] Columns { get; }
        IEnumerable<ICategory> Categories { get; }
        int NumberOfTurns { get; }
        string CategoryCssClassName { get; }
        string ColumnCssClassName { get; }
    }
}
