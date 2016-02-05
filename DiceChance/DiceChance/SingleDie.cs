using System;

namespace DiceChance
{
    public class SingleDie
    {
        private int _eyeValue;

        public int EyeValue
        {
            get { return _eyeValue; }
            set
            {
                if (0 < value && value < 7)
                {
                    _eyeValue = value;
                }
            }
        }


        public SingleDie(int startValue)
        {
            EyeValue = startValue;
        }

        public void PrintValue()
        {
            Console.WriteLine(EyeValue);
        }

        public static SingleDie operator ++(SingleDie die)
        {
            if (die.EyeValue < 6)
                return new SingleDie(die.EyeValue + 1);

            if (die.EyeValue == 6)
                return new SingleDie(1);

            // fejlsikring
            return new SingleDie(1);
        }

        public static SingleDie operator --(SingleDie die)
        {
            if (die.EyeValue > 1)
                return new SingleDie(die.EyeValue - 1);

            if (die.EyeValue == 1)
                return new SingleDie(6);

            // fejlsikring
            return new SingleDie(1);
        }
    }
}