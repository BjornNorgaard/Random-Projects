using System;

namespace ConsoleApplication2
{
    public class DiceThings
    {
        readonly int[] _diceArray = {1,1,1};
        int _numberOfAlike = 0;
        readonly int _diceNumber = 6*6*6-1;

        public DiceThings()
        {
            Run();
        }

        public void Run()
        {
            Console.WriteLine("Hello from Run().");
            for (int i = 0; i < _diceNumber; i++)
            {
                CheckForAlike(_diceArray);
                IncrementArray(_diceArray, 3);
                PrintArray();
            }

            Console.WriteLine("Found " + _numberOfAlike + " Alike.");
        }

        private void CheckForAlike(int[] array)
        {
            if (array[0] == array[1] || array[0] == array[2] || array[1] == array[2])
            {
                _numberOfAlike ++;
            }
        }

        public void IncrementArray(int[] array, int size)
        {
            int top = size - 1;

            array[top]++;
            if (array[top] > 6)
            {
                array[top] = 1;
                array[top - 1]++;
                if (array[top - 1] > 6)
                {
                    array[top - 1] = 1;
                    array[top - 2]++;
                    if (array[top - 2] > 6)
                    {
                        array[top - 2] = 1;
                        array[top - 1] = 1;
                        array[top] = 1;
                    }
                }
            }
        }

        public void PrintArray()
        {
            Console.WriteLine("Dice are: " + _diceArray[0] + ", " + _diceArray[1] + ", " + _diceArray[2] + ".");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DiceThings myDiceThings = new DiceThings();
        }
    }
}
