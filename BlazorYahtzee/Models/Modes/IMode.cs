using System.Collections.Generic;
using BlazorYahtzee.Models.Categories;
using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Modes
{
    public interface IMode
    {
        ModeType Type { get; }
        IEnumerable<IColumn> Columns { get; }
        IEnumerable<ICategory> Categories { get; }
        int NumberOfDice { get; }
        int NumberOfTurns { get; }
        int NumberOfRolls{ get; }
        string CategoryCssClassName { get; }
        string ColumnCssClassName { get; }
    }
}
