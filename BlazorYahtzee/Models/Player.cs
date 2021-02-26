using System.Collections.Generic;
using System.Linq;
using BlazorYahtzee.Models.Columns;

namespace BlazorYahtzee.Models
{
    public class Player
    {
        public Dice Dice { get; } = new Dice();

        private readonly IList<Plays> _plays = new List<Plays>();

        public int RollsRemaining { get; private set; } = 3;

        public bool HasForcedPlay { get; private set; }

        public Player(IEnumerable<ColumnType> columns)
        {
            foreach (var column in columns)
            {
                _plays.Add(new Plays(column));
            }
        }

        public Plays Plays(ColumnType type) => _plays.Single(x => x.Type == type);

        public void RollDice()
        {
            RollsRemaining--;

            foreach (var die in Dice.NotHeldCollection)
            {
                die.Roll();
            }
        }

        public void HoldAllDice()
        {
            foreach (var die in Dice.NotHeldCollection)
            {
                die.Hold();
            }
        }

        public bool IsStartOfTurn()
        {
            return RollsRemaining == 3;
        }

        public bool IsEndOfTurn()
        {
            return RollsRemaining == 0;
        }

        public void ForcePlay()
        {
            HasForcedPlay = true;
        }

        public void ResetTurn()
        {
            Dice.Release();
            HasForcedPlay = false;
            RollsRemaining = 3;
        }

        public void RemoveRemainingRolls()
        {
            RollsRemaining = 0;
        }

        public int TotalScore()
        {
            return _plays.Sum(x => x.TotalScore());
        }
    }
}