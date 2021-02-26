using System.Collections.Generic;
using BlazorYahtzee.Models.Categories;
using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models.Modes
{
    public class Plus : IMode
    {
        public ModeType Type { get; } = ModeType.Plus;

        public IEnumerable<IColumn> Columns { get; } = new List<IColumn>
        {
            new Down(),
            new Up(),
            new Free(),
            new Announce()
        };

        public IEnumerable<ICategory> Categories { get; } = new List<ICategory>
        {
            new Aces(),
            new Twos(),
            new Threes(),
            new Fours(),
            new Fives(),
            new Sixes(),
            new Pair(),
            new TwoPair(),
            new ThreeOfAKind(),
            new FourOfAKind(),
            new FullHouse(),
            new SmallStraight(),
            new LargeStraight(),
            new Yahtzee(),
            new Chance()
        };

        public int NumberOfDice { get; } = 3;
        public int NumberOfTurns { get; } = 60;
        public string CategoryCssClassName { get; } = "col-4";
        public string ColumnCssClassName { get; } = "col-2";
    }
}