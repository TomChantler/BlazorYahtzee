using System;
using System.Linq;
using BlazorYahtzee.Models.Modes;

namespace BlazorYahtzee.Models
{
    public class Game
    {
        public IMode Mode { get; }
        public Player Player { get; }
        public int TurnsRemaining { get; set; }

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
    }
}
