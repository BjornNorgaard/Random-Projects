using System;
using System.Security.Permissions;

namespace DiceChance.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            CombinationOfDice myCombinationOfDice = new CombinationOfDice(3);
            myCombinationOfDice.Print();
            for (int i = 0; i < 215; i++)
            {
                myCombinationOfDice.Increment();
                myCombinationOfDice.Print();
            }

            //Console.WriteLine("Found {0} alike.", myCombinationOfDice.Find());
            Console.WriteLine("Found "+ myCombinationOfDice.Find()+" alike.");
        }
    }
}
