using System;
using System.Collections.Generic;
using System.Linq;
using BlazorYahtzee.Models.Categories;
using BlazorYahtzee.Models.Modes;

namespace BlazorYahtzee.Models
{
    public class Game
    {
        public IMode Mode { get; }
        public Player Player { get; }
        public int TurnsRemaining { get; private set; }

        public IEnumerable<ICategory> UpperSectionCategories() => Mode.Categories.Where(x => x.Section == SectionType.Upper);
        public IEnumerable<ICategory> LowerSectionCategories() => Mode.Categories.Where(x => x.Section == SectionType.Lower);

        public Game(ModeType modeType)
        {
            var mode = modeType switch
            {
                ModeType.Standard => (IMode) new Standard(),
                ModeType.Plus => new Plus(),
                _ => throw new ArgumentOutOfRangeException(nameof(modeType), modeType, null)
            };

            Mode = mode;
            Player = new Player(mode.Columns.Select(x => x.Type));
            TurnsRemaining = mode.NumberOfTurns;
        }

        public bool IsOver()
        {
            return TurnsRemaining == 0;
        }

        public int CurrentRoll()
        {
            return IsOver() ? Mode.NumberOfDice : Mode.NumberOfDice - Player.RollsRemaining;
        }

        public int CurrentTurn()
        {
            return IsOver() ? Mode.NumberOfTurns : Mode.NumberOfTurns - TurnsRemaining + 1;
        }

        public void NextTurn()
        {
            TurnsRemaining--;
            Player.ResetTurn();
        }
    }
}
