using System.Collections.Generic;
using BlazorYahtzee.Models.Categories;

namespace BlazorYahtzee.Models.Modes
{
    public class Standard : IMode
    {
        public ModeType Type { get; } = ModeType.Standard;

        public ColumnType[] Columns { get; } =
        {
            ColumnType.Free
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

        public int NumberOfTurns { get; } = 13;
    }
}