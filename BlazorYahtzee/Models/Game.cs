using System;
using System.Linq;
using BlazorYahtzee.Models.Modes;

namespace BlazorYahtzee.Models
{
    public class Game
    {
        public IMode Mode { get; }
        public Player Player { get; }
        public int TurnsRemaining { get; private set; }

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
            return IsOver() ? 3 : 3 - Player.RollsRemaining;
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
