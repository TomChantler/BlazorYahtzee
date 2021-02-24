using System.Collections.Generic;
using System.Linq;

namespace BlazorYahtzee.Models
{
    public class Player
    {
        public Dice Dice { get; } = new Dice();

        private readonly IList<Plays> _plays = new List<Plays>();

        public bool HasForcedPlay { get; private set; }

        public Player()
        {
            _plays.Add(new Plays(ColumnType.Free));
        }

        public Plays Plays(ColumnType type) => _plays.Single(x => x.Type == type);
        
        public void ForcePlay()
        {
            HasForcedPlay = true;
        }

        public void ResetTurn()
        {
            Dice.Release();
            HasForcedPlay = false;
        }
    }
}