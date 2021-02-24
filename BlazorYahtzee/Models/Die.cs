namespace BlazorYahtzee.Models
{
    public class Die
    {
        public int Value { get; private set; }

        public bool IsHeld { get; private set; }

        public DieState State { get; private set; } = DieState.Normal;

        public void AssignValue(int value)
        {
            Value = value;
        }

        public void Hold()
        {
            IsHeld = !IsHeld;
        }

        public void Release()
        {
            IsHeld = false;
        }

        public void Roll()
        {
            State = DieState.Rolling;
        }

        public void Stop()
        {
            State = DieState.Normal;
        }

        public string ClassName()
        {
            var dieClass = Value switch
            {
                1 => "one",
                2 => "two",
                3 => "three",
                4 => "four",
                5 => "five",
                6 => "six",
                _ => "one"
            };

            return IsHeld ? $"{dieClass} text-primary" : dieClass;
        }
    }
}
