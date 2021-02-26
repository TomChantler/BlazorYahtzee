using System.Collections.Generic;
using System.Linq;
using BlazorYahtzee.Models.Columns;
using BlazorYahtzee.Models.Modes;

namespace BlazorYahtzee.Models
{
    public class Player
    {
        public Dice Dice { get; } = new Dice();

        private readonly IList<Plays> _plays = new List<Plays>();

        public int NumberOfRolls { get; }

        public int RollsRemaining { get; private set; }

        public bool HasForcedPlay { get; private set; }

        public Player(IMode mode)
        {
            foreach (var columnType in mode.Columns.Select(x => x.Type))
            {
                _plays.Add(new Plays(columnType));
            }

            NumberOfRolls = mode.NumberOfRolls;
            RollsRemaining = mode.NumberOfRolls;
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
            return RollsRemaining == NumberOfRolls;
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
            RollsRemaining = NumberOfRolls;
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