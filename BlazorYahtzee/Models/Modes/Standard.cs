using System.Collections.Generic;
using BlazorYahtzee.Models.Categories;
using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Modes
{
    public class Standard : IMode
    {
        public ModeType Type { get; } = ModeType.Standard;

        public IEnumerable<IColumn> Columns { get; } = new List<IColumn>
        {
            new Free()
        };

        public IEnumerable<ICategory> Categories { get; } = new List<ICategory>
        {
            new Aces(),
            new Twos(),
            new Threes(),
            new Fours(),
            new Fives(),
            new Sixes(),
            new ThreeOfAKind(),
            new FourOfAKind(),
            new FullHouse(),
            new SmallStraight(),
            new LargeStraight(),
            new Yahtzee(),
            new Chance()
        };

        public int NumberOfDice { get; } = 3;
        public int NumberOfTurns { get; } = 13;
        public string CategoryCssClassName { get; } = "col-6";
        public string ColumnCssClassName { get; } = "col-6";
    }
}