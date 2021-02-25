using System.Collections.Generic;
using BlazorYahtzee.Models.Categories;

namespace BlazorYahtzee.Models.Modes
{
    public class Plus : IMode
    {
        public ModeType Type { get; } = ModeType.Plus;

        public ColumnType[] Columns { get; } =
        {
            ColumnType.Down, 
            ColumnType.Up, 
            ColumnType.Free, 
            ColumnType.Announce
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

        public int NumberOfTurns { get; } = 60;
    }
}