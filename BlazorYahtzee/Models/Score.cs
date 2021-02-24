using System;

namespace BlazorYahtzee.Models
{
    public class Score
    {
        public int Points { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public Score()
        {
        }

        public Score(int points)
        {
            Points = points;
        }
    }
}