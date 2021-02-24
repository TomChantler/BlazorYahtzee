namespace BlazorYahtzee.Models
{
    public class Player
    {
        public Dice Dice { get; } = new Dice();
        public Plays Plays { get; } = new Plays();

        public bool HasForcedPlay { get; private set; }

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